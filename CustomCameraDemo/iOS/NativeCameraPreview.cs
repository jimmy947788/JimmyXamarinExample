using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AssetsLibrary;
using AVFoundation;
using CoreGraphics;
using CoreImage;
using CustomCameraDemo.Enums;
using Foundation;
using UIKit;

namespace CustomCameraDemo.iOS
{
	public class NativeCameraPreview : UIView
	{
		AVCaptureVideoPreviewLayer previewLayer;
		CameraOptions cameraOptions;

		public AVCaptureSession CaptureSession { get; private set; }

		public NativeCameraPreview(CameraOptions options)
		{
			cameraOptions = options;
			Initialize();
		}

		public override void Draw(CGRect rect)
		{
			base.Draw(rect);
			previewLayer.Frame = rect;
		}

		void Initialize()
		{
			CaptureSession = new AVCaptureSession();
			previewLayer = new AVCaptureVideoPreviewLayer(CaptureSession)
			{
				Frame = Bounds,
				VideoGravity = AVLayerVideoGravity.ResizeAspectFill
			};

			var videoDevices = AVCaptureDevice.DevicesWithMediaType(AVMediaType.Video);
			var cameraPosition = (cameraOptions == CameraOptions.Front) ? AVCaptureDevicePosition.Front : AVCaptureDevicePosition.Back;
			var device = videoDevices.FirstOrDefault(d => d.Position == cameraPosition);

			if (device == null)
			{
				return;
			}

			NSError error;
			var input = new AVCaptureDeviceInput(device, out error);
			CaptureSession.AddInput(input);
			Layer.AddSublayer(previewLayer);
			CaptureSession.StartRunning();

            //拍照
			outputSession = new AVCaptureStillImageOutput();
			var dict = new NSMutableDictionary();
			dict[AVVideo.CodecKey] = new NSNumber((int)AVVideoCodec.JPEG);
			CaptureSession.AddOutput(outputSession);
		}

        AVCaptureStillImageOutput outputSession;

		public async Task<Stream> CaptureImage()
		{
            //取得影像資料
            var connection = outputSession.Connections[0];
			var sampleBuffer = await outputSession.CaptureStillImageTaskAsync(connection);
			var imageData = AVCaptureStillImageOutput.JpegStillToNSData(sampleBuffer);

            //將影像資料轉成byte array
			byte[] dataBytes = new byte[imageData.Length];
			System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, dataBytes, 0, Convert.ToInt32(imageData.Length));

			var image = CIImage.FromData(imageData);
			var metadata = image.Properties.Dictionary.MutableCopy() as NSMutableDictionary;

			//將影像資料存到相簿
			ALAssetsLibrary library = new ALAssetsLibrary();
			library.WriteImageToSavedPhotosAlbum(imageData, metadata, (assetUrl, error) =>
			{
				if (error == null)
				{
					Console.WriteLine("assetUrl:" + assetUrl);
				}
				else
				{
					Console.WriteLine(error);
				}
			});

			//將byte array轉成Stream丟出去
			return new MemoryStream(dataBytes);
		}

		CameraOptions cameraOption = CameraOptions.Rear;
		public CameraOptions CameraOption
		{
			get { return cameraOption; }
			set
			{
				cameraOption = value;

				CaptureSession.BeginConfiguration();
				AVCaptureInput currentCameraInput = CaptureSession.Inputs[0];
				CaptureSession.RemoveInput(currentCameraInput);

				AVCaptureDevice newCamera = null;
				//if (((AVCaptureDeviceInput)currentCameraInput).Device.Position == AVCaptureDevicePosition.Back)
				if (cameraOption == CameraOptions.Front)
				{
					newCamera = CameraWithPosition(AVCaptureDevicePosition.Front);
				}
				else
				{
					newCamera = CameraWithPosition(AVCaptureDevicePosition.Back);
				}

				NSError err = null;

				AVCaptureDeviceInput newVideoInput = new AVCaptureDeviceInput(newCamera, out err);

				CaptureSession.AddInput(newVideoInput);

				CaptureSession.CommitConfiguration();
			}
		}

        private AVCaptureDevice CameraWithPosition(AVCaptureDevicePosition position)
        {
			var defaultCamera = AVCaptureDevice.GetDefaultDevice(
                AVCaptureDeviceType.BuiltInWideAngleCamera, 
                AVMediaType.Video, position);
            return defaultCamera;
        }
	}
}
