using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace TableViewDemo
{
	public partial class MyTableViewDemoPage : ContentPage
	{
		public MyTableViewDemoPage()
		{
			InitializeComponent();
		}

		void Save_Clicked(object sender, EventArgs e)
		{
			Debug.WriteLine("Switch IsToggled:{0}", mySwitch.IsToggled);
			Debug.WriteLine("Picker Text:{0}", myPicker.Text);
			Debug.WriteLine("Entry Text:{0}", myEntery.Text);
		}
	}
}
