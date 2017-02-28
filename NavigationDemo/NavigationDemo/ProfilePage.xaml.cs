using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace NavigationDemo
{
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Debug.WriteLine("ProfilePage OnAppearing()");
			//(App.Current as App).NavPage.BarTextColor = Color.White;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Debug.WriteLine("ProfilePage OnDisappearing()");
			//(App.Current as App).NavPage.BarTextColor = Color.Black;
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}
