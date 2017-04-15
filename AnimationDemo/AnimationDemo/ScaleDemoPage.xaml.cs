using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class ScaleDemoPage : ContentPage
	{
		public ScaleDemoPage()
		{
			InitializeComponent();
		}

		void Scale_Click(object sender, EventArgs e)
		{
			var button = sender as Button;
			var scale = double.Parse(button.CommandParameter.ToString());
			logo.ScaleTo(scale);
		}
	}
}
