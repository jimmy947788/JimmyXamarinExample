using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class FadeDemoPage : ContentPage
	{
		async void FadeIn_Clicked(object sender, System.EventArgs e)
		{
			//logo1.Opacity = 0;
			await logo1.FadeTo(1, 3000);
		}

		async void FadeOut_Clicked(object sender, System.EventArgs e)
		{
			//logo2.Opacity = 0;
			await logo2.FadeTo(0, 3000);
		}

		public FadeDemoPage()
		{
			InitializeComponent();
		}
	}
}
