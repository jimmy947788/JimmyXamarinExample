using System;
using CoreGraphics;
using UIKit;

namespace NativeBinding
{
    public partial class ViewController : UIViewController
    {
		MyLibraryBinding.CustomView customView;
        MyLibraryBinding.UtilityCallbackDelegate myCallback;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            var utilities = new MyLibraryBinding.Utilities();
            var sayHelio = utilities.Hello("Jimmy");
            Console.WriteLine(sayHelio);

			var xmUtilities = new MyLibraryBinding.Utilities();
			myCallback = (arg0) =>
			{
				Console.WriteLine($"callback message is {arg0}");
			};
			xmUtilities.SetCallback(myCallback);
			xmUtilities.InvokeCallback("這就摳背");

			customView = new MyLibraryBinding.CustomView();
			customView.CustomizeView(new CGRect(0, 50, this.View.Frame.Width, 30), "爽嗎？爽嗎？爽嗎？爽嗎？");
			this.View.AddSubview(customView);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
