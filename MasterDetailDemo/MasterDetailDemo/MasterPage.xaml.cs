using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MasterDetailDemo
{
	public partial class MasterPage : ContentPage
	{
		public MasterPage()
		{
			InitializeComponent();
		}

		void OnItemSelected(object sender, System.EventArgs e)
		{
			//var myPage = this.Parent as DemoMasterDetailPage;

			//myPage.IsPresented = false;
		}
	}
}
