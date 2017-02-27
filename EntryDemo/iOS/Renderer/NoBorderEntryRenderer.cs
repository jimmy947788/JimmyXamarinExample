using System;
using Xamarin.Forms;
using EntryDemo;
using EntryDemo.Controls;
using EntryDemo.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEntryRenderer))]
namespace EntryDemo.iOS.Renderer
{
	public class NoBorderEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
			}

			if (e.NewElement != null)
			{
				// Configure the native control and subscribe to event handlers
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
			}
		}
	}
}
