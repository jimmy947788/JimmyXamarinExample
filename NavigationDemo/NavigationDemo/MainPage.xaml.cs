using System.Diagnostics;
using Xamarin.Forms;

namespace NavigationDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = this;
		}

		async void GoToProfile_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new ProfilePage());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			Debug.WriteLine("MainPage OnAppearing()");
			//(App.Current as App).NavPage.BarTextColor = Color.White;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			Debug.WriteLine("MainPage OnDisappearing()");
			//(App.Current as App).NavPage.BarTextColor = Color.Black;
		}
	}
}
