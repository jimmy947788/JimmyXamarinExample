using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TabbedPageDemo
{
	public partial class MyTabbPage : ContentPage
	{
		void Demo1_Tapped(object sender, System.EventArgs e)
		{
			var page = new DemoPage1();
			cvContentPlaceHolder.Content = page.Content;
		}
		void Demo2_Tapped(object sender, System.EventArgs e)
		{
			var page = new DemoPage2();
			cvContentPlaceHolder.Content = page.Content;
		}
		void Demo3_Tapped(object sender, System.EventArgs e)
		{
			var page = new DemoPage3();
			cvContentPlaceHolder.Content = page.Content;
		}

		public MyTabbPage()
		{
			InitializeComponent();
		}
	}
}
