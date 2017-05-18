using System;
using Android.Hardware;
using CustomCameraDemo.Controls;
using CustomCameraDemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraPreviewRenderer))]
namespace CustomCameraDemo.Droid.Renderers
{
    public class CameraPreviewRenderer : ViewRenderer<CameraPreview, NativeCameraPreview>
    {
		NativeCameraPreview nativeCameraPreview;

		protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				nativeCameraPreview = new NativeCameraPreview(Context);
				SetNativeControl(nativeCameraPreview);
			}

			if (e.OldElement != null)
			{
				// Unsubscribe
			}
			if (e.NewElement != null)
			{
				Control.Preview = Camera.Open((int)e.NewElement.Camera);

                // Subscribe
                e.NewElement.TakePhotoAsync = async () =>
                {
                    var stream = await nativeCameraPreview.CaptureImage();
                    return ImageSource.FromStream(()=> stream);
                };

                e.NewElement.SwitchCamera = (cameraOption) =>
                {
                    nativeCameraPreview.CameraOption = cameraOption;
                    return true;
                };
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Control.Preview.Release();
			}
			base.Dispose(disposing);
		}
    }
}
