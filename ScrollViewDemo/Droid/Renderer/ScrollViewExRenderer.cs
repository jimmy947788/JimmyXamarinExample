using System;
using System.ComponentModel;
using ScrollViewDemo.Controls;
using ScrollViewDemo.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollView), typeof(ScrollViewExRenderer))]
namespace ScrollViewDemo.Droid.Renderer
{
	public class ScrollViewExRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				// Unsubscribe from event handlers and cleanup any resources
				e.OldElement.PropertyChanged -= OnElementPropetyChanged;
			}

			if (e.NewElement != null)
			{
				// Configure the control and subscribe to event handlers 
				e.NewElement.PropertyChanged += OnElementPropetyChanged;
			}
		}

		private void OnElementPropetyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (ChildCount > 0)
			{
				//this.HorizontalScrollBarEnabled = false;
				GetChildAt(0).HorizontalScrollBarEnabled = false;
				GetChildAt(0).VerticalScrollBarEnabled = false;
			}
		}
	}
}
