using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ListViewDemo
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage(int id, string name)
		{
			InitializeComponent();

			Title = name;
			webView.Source = string.Format("http://my.tokyo-hot.com/cast/{0}/", id);
		}
	}
}
