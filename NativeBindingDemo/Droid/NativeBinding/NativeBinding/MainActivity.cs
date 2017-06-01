using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace NativeBinding
{
    [Activity(Label = "NativeBinding", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, Com.Daedalus.Mylibrary.IUtilityCallback
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };

			var echo = Com.Daedalus.Mylibrary.Utilities.Echo("有沒有人在家??");
			System.Console.WriteLine($"---->{echo}");

			var utilities = new Com.Daedalus.Mylibrary.Utilities();
			var sayhello = utilities.Hello("Jimmy");
			System.Console.WriteLine(sayhello);

			utilities.SetCallback(this);
			utilities.InvokeCallback("靠北靠北靠北");
		}

		public void CallbackCall(string p0)
		{
			System.Console.WriteLine($"this is callback message {p0}");
		}
    }
}

