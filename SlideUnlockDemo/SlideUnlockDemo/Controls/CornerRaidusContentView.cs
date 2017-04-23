using System;
using Xamarin.Forms;

namespace SlideUnlockDemo.Controls
{
	public class CornerRaidusContentView : ContentView
	{
		public static readonly BindableProperty CornerRaidusProperty = BindableProperty.Create(
				"CornerRaidus",
				typeof(double),
				typeof(CornerRaidusContentView),
				0.0D
			);
			
		public double CornerRaidus
		{
			get { return (double)GetValue(CornerRaidusProperty); }
			set { SetValue(CornerRaidusProperty, value); }
		}
	}
}
