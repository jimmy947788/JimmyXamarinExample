using System;
using Android.Support.V4.Content;
using TableViewDemo.Controls;
using TableViewDemo.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NoBorderEntry), typeof(NoBorderEntryRenderer))]
namespace TableViewDemo.Droid.Renderer
{
	public class NoBorderEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (this.Control != null)
			{
				this.Control.Background = ContextCompat.GetDrawable(this.Context, Resource.Layout.NoBorderEditText);
				this.Control.Background.Alpha = 0;
				this.Control.Gravity = Android.Views.GravityFlags.Left;
				this.Control.SetPadding(0, 0, 0, 0);
			}
		}
	}
}
