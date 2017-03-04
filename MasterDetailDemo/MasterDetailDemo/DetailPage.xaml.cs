using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MasterDetailDemo
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage()
		{
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			var myPage = 
				this.Parent as MasterDetailDemoPage;

			myPage.IsPresented = true;
		}
	}
}
