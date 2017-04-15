using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class TranslateDemoPage : ContentPage
	{
		public TranslateDemoPage()
		{
			InitializeComponent();
		}

		void TranslateX_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			var offset = int.Parse(button.CommandParameter.ToString());
			logo.TranslateTo(offset, 0);		
		}

		void TranslateY_Clicked(object sender, System.EventArgs e)
		{
			var button = sender as Button;
			var offset = int.Parse(button.CommandParameter.ToString());
			logo.TranslateTo(0, offset);
		}
	}
}
