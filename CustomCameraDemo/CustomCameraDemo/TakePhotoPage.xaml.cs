using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CustomCameraDemo
{
    public partial class TakePhotoPage : ContentPage
    {
        public TakePhotoPage()
        {
            InitializeComponent();
        }

        ImageSource photoSource;
        public ImageSource PhotoSource 
        {
            get { return photoSource; }
        }
        protected async void imgTakePhoto_Tapped(object sender, EventArgs e)
        {
            photoSource = await cameraPreview.TakePhotoAsync();

            await Navigation.PopModalAsync();
        }

        protected void imgSwitchCamera_Tapped(object sender, EventArgs e)
        {
            if(cameraPreview.Camera == Enums.CameraOptions.Front)
            {
                cameraPreview.Camera = Enums.CameraOptions.Rear;
            }
            else
            {
                cameraPreview.Camera = Enums.CameraOptions.Front;    
            }
            cameraPreview.SwitchCamera(cameraPreview.Camera);
        }
    }
}
