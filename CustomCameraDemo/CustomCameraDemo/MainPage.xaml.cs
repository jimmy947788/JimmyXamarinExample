using System;
using Xamarin.Forms;

namespace CustomCameraDemo
{
    public partial class MainPage : ContentPage
    {
        TakePhotoPage takePhotoPage;
        public MainPage()
        {
            InitializeComponent();

            takePhotoPage = new TakePhotoPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(takePhotoPage.PhotoSource != null)
            {
				imgPhoto.Source = takePhotoPage.PhotoSource;
            }
        }
        protected async void btnTakePhoto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(takePhotoPage);
        }
    }
}
