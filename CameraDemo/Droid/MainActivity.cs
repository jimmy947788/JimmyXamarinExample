using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Platform.Services.Media;

namespace CameraDemo.Droid
{
    [Activity(Label = "CameraDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            SetIoc();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }

		private void SetIoc()
		{
			var resolverContainer = new global::XLabs.Ioc.SimpleContainer();
			resolverContainer
				.Register<IMediaPicker, MediaPicker>();

			XLabs.Ioc.Resolver.SetResolver(resolverContainer.GetResolver());
		}
    }
}
