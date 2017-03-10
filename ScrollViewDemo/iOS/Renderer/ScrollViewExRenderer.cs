using System;
using Xamarin.Forms;
using ScrollViewDemo.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ScrollView), typeof(ScrollViewExRenderer))]
namespace ScrollViewDemo.iOS.Renderer
{
	public class ScrollViewExRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{     
				// Unsubscribe from event handlers and cleanup any resources   
				e.OldElement.PropertyChanged -= OnElementPropertyChanged;
			}   

			if (e.NewElement != null) {
				// Configure the control and subscribe to event handlers 
				e.NewElement.PropertyChanged += OnElementPropertyChanged;
			}
		}

		private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.ShowsHorizontalScrollIndicator = false;
			this.ShowsVerticalScrollIndicator = false;
		}
	}
}
