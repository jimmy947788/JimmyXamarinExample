using System;
using System.Collections;
using System.Collections.Generic;
using ScrollViewDemo.Controls;
using Xamarin.Forms;

namespace ScrollViewDemo
{
	public partial class MainPage : ContentPage
	{
		void Handle_ItemSelectd(object sender, ScrollViewDemo.Controls.HMenuItemSelectdEventArgs e)
		{
			var index = int.Parse(e.Value);
			scrollView.ScrollToAsync(400 * index, 0, true);
		}

		public MainPage()
		{
			InitializeComponent();

			var photos = new List<HMenuItem>();
			photos.Add(new HMenuItem
			{
				Text = "Photo1",
				Value = 0,
				Selected = true
			});
			photos.Add(new HMenuItem
			{
				Text = "Photo2",
				Value = 1,
				Selected = false
			});
			photos.Add(new HMenuItem
			{
				Text = "Photo3",
				Value = 2,
				Selected = false
			});
			photos.Add(new HMenuItem
			{
				Text = "Photo4",
				Value = 3,
				Selected = false
			});
			photos.Add(new HMenuItem
			{
				Text = "Photo5",
				Value = 4,
				Selected = false
			});
			hMenuView.Items = photos;
		}

		//void Photo1_Click(object sender, EventArgs e)
		//{
		//	//scrollView.ScrollToAsync(image3, ScrollToPosition., true);
		//	scrollView.ScrollToAsync(400 * 0, 0, true);
		//}

		//void Photo2_Click(object sender, EventArgs e)
		//{
		//	scrollView.ScrollToAsync(400 * 1, 0, true);
		//}

		//void Photo3_Click(object sender, EventArgs e)
		//{
		//	scrollView.ScrollToAsync(400 * 2, 0, true);
		//}

		//void Photo4_Click(object sender, EventArgs e)
		//{
		//	scrollView.ScrollToAsync(400 * 3, 0, true);
		//}

		//void Photo5_Click(object sender, EventArgs e)
		//{
		//	scrollView.ScrollToAsync(400 * 4, 0, true);
		//}
	}
}
