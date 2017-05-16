using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Platform.Services.Media;

namespace CameraDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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
			var resolverContainer = new global::XLabs.Ioc.SimpleContainer();
			resolverContainer
				.Register<IMediaPicker, MediaPicker>();

			XLabs.Ioc.Resolver.SetResolver(resolverContainer.GetResolver());
		}
    }
}
