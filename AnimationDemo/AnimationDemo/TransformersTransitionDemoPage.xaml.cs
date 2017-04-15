using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class TransformersTransitionDemoPage : ContentPage
	{
		public TransformersTransitionDemoPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await logo.ScaleTo(0.3, 500);
			await logo.RotateYTo(90, 500);
			logo.Source = "DECEPTICON.gif";
			await logo.RotateYTo(180, 500);
			logo.ScaleTo(1, 500);
			logo.FadeTo(0, 500);
		}
	}
}
