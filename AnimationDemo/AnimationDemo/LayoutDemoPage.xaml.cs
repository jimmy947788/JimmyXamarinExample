using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class LayoutDemoPage : ContentPage
	{
		public LayoutDemoPage()
		{
			InitializeComponent();
		}

		async void Play_Clicked(object sender, EventArgs e)
		{
			gohan.Source = "A002.png";
			await Task.Delay(500);
			gohan.Source = "A003.png";
			await Task.Delay(500);
			power.IsVisible = true;
			await Task.Delay(100);
			await power.LayoutTo(new Rectangle { 
				X = power.X,
				Y = power.Y,
				Width = 300,
				Height = power.Height
			},1000);
		}
	}
}
