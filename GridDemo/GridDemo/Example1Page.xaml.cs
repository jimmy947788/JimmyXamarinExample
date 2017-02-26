using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace GridDemo
{
	public partial class Example1Page : ContentPage
	{
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var numberButton = (sender as Button);
			var number = numberButton.Text;

			lblNumber.Text += number;
			//throw new NotImplementedException();
		}

		void Dial_Click(object sender, System.EventArgs e)
		{
			Debug.WriteLine("Dialing {0}...", lblNumber.Text);
		}

		public Example1Page()
		{
			InitializeComponent();
		}
	}
}
