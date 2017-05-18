using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.Hardware;
using Android.Runtime;
using Android.Util;
using Android.Views;
using CustomCameraDemo.Enums;
using Java.IO;

namespace CustomCameraDemo.Droid
{
    public class NativeCameraPreview : ViewGroup, ISurfaceHolderCallback,
        Camera.IShutterCallback,
        Camera.IPictureCallback
    {
		SurfaceView surfaceView;
		ISurfaceHolder holder;
		Camera.Size previewSize;
		IList<Camera.Size> supportedPreviewSizes;
		Camera camera;
		IWindowManager windowManager;

		public Camera Preview
        {
            get { return camera; }
            set
            {
                camera = value;
                if (camera != null)
                {
                    supportedPreviewSizes = Preview.GetParameters().SupportedPreviewSizes;
                    RequestLayout();
                }
            }
        }

		public NativeCameraPreview(Context context)
            : base (context)
        {
			surfaceView = new SurfaceView(context);
			AddView(surfaceView);

			windowManager = Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

			holder = surfaceView.Holder;
			holder.AddCallback(this);
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			int width = ResolveSize(SuggestedMinimumWidth, widthMeasureSpec);
			int height = ResolveSize(SuggestedMinimumHeight, heightMeasureSpec);
			SetMeasuredDimension(width, height);

			if (supportedPreviewSizes != null)
			{
                previewSize = GetOptimalPreviewSize(supportedPreviewSizes, width, height);
			}
		}

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
			var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

			surfaceView.Measure(msw, msh);
			surfaceView.Layout(0, 0, r - l, b - t);
		}

		public void SurfaceCreated(ISurfaceHolder holder)
		{
			try
			{
				if (Preview != null)
                {
					Preview.SetPreviewDisplay(holder);
				}
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(@"          ERROR: ", ex.Message);
			}
		}

		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			if (Preview != null)
			{
				Preview.StopPreview();
			}
		}

        int beginWidth;
        int beginHeight;
		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int width, int height)
		{
            beginWidth = width;
            beginHeight = height;
            var parameters = Preview.GetParameters();
			parameters.SetPreviewSize(previewSize.Width, previewSize.Height);
			RequestLayout();

			switch (windowManager.DefaultDisplay.Rotation)
			{
				case SurfaceOrientation.Rotation0:
					//camera.SetDisplayOrientation(90);
					parameters.SetPreviewSize(height, width);
                    camera.SetDisplayOrientation(90);
					break;
				case SurfaceOrientation.Rotation90:
					//camera.SetDisplayOrientation(0);
                    parameters.SetPreviewSize(width, height);
					break;
                case SurfaceOrientation.Rotation180:
                    parameters.SetPreviewSize(width, height);
                    break;
				case SurfaceOrientation.Rotation270:
					//camera.SetDisplayOrientation(180);
					parameters.SetPreviewSize(width, height);
					camera.SetDisplayOrientation(180);
					break;
			}

			Preview.SetParameters(parameters);
			Preview.StartPreview();
		}

		Camera.Size GetOptimalPreviewSize(IList<Camera.Size> sizes, int w, int h)
		{
			const double AspectTolerance = 0.1;
			double targetRatio = (double)w / h;

			if (sizes == null)
			{
				return null;
			}

			Camera.Size optimalSize = null;
			double minDiff = double.MaxValue;

			int targetHeight = h;
			foreach (Camera.Size size in sizes)
			{
				double ratio = (double)size.Width / size.Height;

				if (Math.Abs(ratio - targetRatio) > AspectTolerance)
					continue;
				if (Math.Abs(size.Height - targetHeight) < minDiff)
				{
					optimalSize = size;
					minDiff = Math.Abs(size.Height - targetHeight);
				}
			}

			if (optimalSize == null)
			{
				minDiff = double.MaxValue;
				foreach (Camera.Size size in sizes)
				{
					if (Math.Abs(size.Height - targetHeight) < minDiff)
					{
						optimalSize = size;
						minDiff = Math.Abs(size.Height - targetHeight);
					}
				}
			}

			return optimalSize;
		}

        TaskCompletionSource<Stream> tcs = new TaskCompletionSource<Stream>();
        public Task<Stream> CaptureImage()
        {
            camera.TakePicture(this, null, this);
            return tcs.Task;   
        }

        public void OnShutter()
        {
            //throw new NotImplementedException();
        }

      
        public void OnPictureTaken(byte[] data, Camera camera)
        {
            //取得Ａndroid DCIM路徑
            var pathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDcim);
			var absolutePath = pathFile.AbsolutePath;
            var filename = "test.jpg";
            //將檔案寫入DCIM路徑
            System.IO.File.WriteAllBytes(System.IO.Path.Combine(absolutePath, filename), data);


            //他媽的照出來的照片要自己旋轉90度才會正向
            var stream = new MemoryStream();
            using (var orgBmp = ToBitmap(data))
            using (var newBmp = Rotate(orgBmp, 90))
            {
                newBmp.Compress(Android.Graphics.Bitmap.CompressFormat.Jpeg, 100, stream);
                //要加這個seek不然stream無法顯示於ImageSource
                stream.Seek(0L, SeekOrigin.Begin);
                tcs.SetResult(stream);
            }
        }

		public static Android.Graphics.Bitmap ToBitmap(byte[] data)
		{
            return Android.Graphics.BitmapFactory.DecodeByteArray(data, 0, data.Length);
		}

        public static Android.Graphics.Bitmap Rotate(Android.Graphics.Bitmap bitmap, int angle)
        {
            var mat = new Android.Graphics.Matrix();
            mat.PostRotate(angle);
            return Android.Graphics.Bitmap.CreateBitmap(bitmap, 0, 0, bitmap.Width, bitmap.Height, mat, true);
        }

		CameraOptions cameraOption = CameraOptions.Rear;
		public CameraOptions CameraOption
		{
			get { return cameraOption; }
			set
			{
				cameraOption = value;
				camera.StopPreview();
				//NB: if you don't release the current camera before switching, you app will crash
				camera.Release();

				if (cameraOption == CameraOptions.Rear)
					camera = Camera.Open((int)Camera.CameraInfo.CameraFacingBack);
				else
					camera = Camera.Open((int)Camera.CameraInfo.CameraFacingFront);

				SurfaceChanged(holder,
							   Android.Graphics.Format.Jpeg,
							   beginWidth,
							   beginHeight);
				camera.SetPreviewDisplay(holder);
				camera.StartPreview();
			}
		}
	}
}
