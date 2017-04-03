using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLiteDemo.Interface;
using SQLiteDemo.SQLiteRepository;

namespace SQliteDemo.Droid
{
	[Activity(Label = "SQliteDemo.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			var databasePath =
				System.IO.Path.Combine(System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.MyDocuments), "database.db3");

			var resolverContainer = new XLabs.Ioc.Unity.UnityDependencyContainer();

			resolverContainer.Register<IActorRepository>(new ActorRepository(databasePath));

			XLabs.Ioc.Resolver.SetResolver(resolverContainer.GetResolver());


			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());
		}
	}
}
