using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using SQLiteDemo.Interface;
using SQLiteDemo.SQLiteRepository;
using UIKit;

namespace SQliteDemo.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			var databasePath =
				System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "database.db3");

			var resolverContainer = new XLabs.Ioc.Unity.UnityDependencyContainer();

			resolverContainer.Register<IActorRepository>(new ActorRepository(databasePath));

			XLabs.Ioc.Resolver.SetResolver(resolverContainer.GetResolver());



			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
