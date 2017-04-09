using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Serialization.JsonNET;

namespace WebViewDemo.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : XLabs.Forms.XFormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			SetIoc();

			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}


		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			resolverContainer
				.Register<IJsonSerializer, JsonSerializer>();
			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}
