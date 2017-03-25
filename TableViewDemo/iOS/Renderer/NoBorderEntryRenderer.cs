using System;
using TableViewDemo.Controls;
using TableViewDemo.iOS.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEntryRenderer))]
namespace TableViewDemo.iOS.Renderer
{
	public class NoBorderEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				// do whatever you want to the UITextField here!
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
				Control.AutocorrectionType = UIKit.UITextAutocorrectionType.No;
			}
		}
	}
}
