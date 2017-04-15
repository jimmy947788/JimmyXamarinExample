using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class FlipDemoPage : ContentPage
	{
		public FlipDemoPage()
		{
			InitializeComponent();
		}

		void FlipX_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			var dregee = double.Parse(button.CommandParameter.ToString());
			logo.RotateXTo(dregee);
		}

		void FlipY_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			var dregee = double.Parse(button.CommandParameter.ToString());
			logo.RotateYTo(dregee);
		}
	}
}
