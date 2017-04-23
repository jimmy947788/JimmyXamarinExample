using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using SlideUnlockDemo.Controls;
using SlideUnlockDemo.iOS.Renderers;
using System;
using UIKit;

[assembly: ExportRenderer(typeof(CornerRaidusContentView), typeof(CornerRaidusContentViewRenderer))]
namespace SlideUnlockDemo.iOS.Renderers
{
	public class CornerRaidusContentViewRenderer : ViewRenderer
	{
		CornerRaidusContentView cornerRaidusContentView;
		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				cornerRaidusContentView = e.NewElement as CornerRaidusContentView;
				Layer.CornerRadius = (nfloat)cornerRaidusContentView.CornerRaidus;
				Layer.MasksToBounds = true;
				BackgroundColor = UIColor.FromRGBA(
					(nfloat)cornerRaidusContentView.BackgroundColor.R,
					(nfloat)cornerRaidusContentView.BackgroundColor.G,
					(nfloat)cornerRaidusContentView.BackgroundColor.B,
					(nfloat)cornerRaidusContentView.BackgroundColor.A);
			}

			if (e.OldElement != null)
			{
			}

			if (Control != null)
			{
			}
		}
	}
}
