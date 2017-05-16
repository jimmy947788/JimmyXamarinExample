using System;
using System.Diagnostics;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Services.Media;

namespace CameraDemo
{
    public partial class MainPage : ContentPage
    {
        IMediaPicker mediaPicker;
        public MainPage()
        {
            InitializeComponent();

            mediaPicker = Resolver.Resolve<IMediaPicker>();
        }

		async void btnTakePicture_Clicked(object sender, EventArgs e)
		{
			var mediaFile = await mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions
			{
                DefaultCamera = CameraDevice.Rear,
				MaxPixelDimension = 400
			});

            Debug.WriteLine($"picture path : {mediaFile.Path}");

			imgPhoto.Source = mediaFile.Path;
		}

		async void btnSelectPicture_Clicked(object sender, EventArgs e)
		{
            var mediaFile = await mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions());

			Debug.WriteLine($"picture path : {mediaFile.Path}");

			imgPhoto.Source = mediaFile.Path;
		}
    }
}
