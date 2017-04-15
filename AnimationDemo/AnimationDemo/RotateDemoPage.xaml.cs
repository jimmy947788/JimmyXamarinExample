using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class RotateDemoPage : ContentPage
	{
		public RotateDemoPage()
		{
			InitializeComponent();
		}

		void Rotat_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			var dregee = double.Parse(button.CommandParameter.ToString());
			logo.RotateTo(dregee);
		}

		void ReRotae_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			var dregee = double.Parse(button.CommandParameter.ToString());
			logo.RelRotateTo(dregee);
		}
	}
}
