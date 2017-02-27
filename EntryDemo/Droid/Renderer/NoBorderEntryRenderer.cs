using System;
using Android.Support.V4.Content;
using EntryDemo.Controls;
using EntryDemo.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEntryRenderer))]
namespace EntryDemo.Droid.Renderer
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
				this.Control.Background = ContextCompat.GetDrawable(this.Context, Resource.Layout.NoBorderEditText);
				this.Control.Background.Alpha = 0;
				this.Control.Gravity = Android.Views.GravityFlags.Left;
				this.Control.SetPadding(0, 0, 0, 0);

			}
		}
	}
}
