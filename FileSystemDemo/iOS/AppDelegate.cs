using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace FileSystemDemo.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			//foreach (var folder in 
			//         Enum.GetValues(typeof(Environment.SpecialFolder)))
			//{
			//	var sfolder = (Environment.SpecialFolder)folder;
			//	var path = System.Environment.GetFolderPath(sfolder);
			//	Console.WriteLine($"{folder}={path}");
			//}


			//var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//var file = System.IO.Path.Combine(path, "MyTest.txt");
			//Console.WriteLine($"Path={file}");
			//System.IO.File.WriteAllText(file, "hello this jimmy");
			return base.FinishedLaunching(app, options);
		}
	}
}
