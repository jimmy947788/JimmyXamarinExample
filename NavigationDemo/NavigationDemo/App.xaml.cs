using Xamarin.Forms;

namespace NavigationDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = navPage = new NavigationPage(new MainPage());
		}

		NavigationPage navPage;
		public NavigationPage NavPage
		{
			get { return navPage; }
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
