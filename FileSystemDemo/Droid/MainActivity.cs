using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FileSystemDemo.Droid
{
	[Activity(Label = "FileSystemDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			//foreach (var folder in 
			//         Enum.GetValues(typeof(System.Environment.SpecialFolder)))
			//{
			//	var sfolder = (System.Environment.SpecialFolder)folder;
			//	var path = System.Environment.GetFolderPath(sfolder);
			//	Console.WriteLine($"{folder}={path}");
			//}

			LoadApplication(new App());
		}
	}
}
