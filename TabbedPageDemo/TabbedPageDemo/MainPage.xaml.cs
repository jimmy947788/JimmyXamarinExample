using Xamarin.Forms;

namespace TabbedPageDemo
{
	public partial class MainPage : TabbedPage
	{
		public MainPage()
		{
			InitializeComponent();


			this.Children.Add(new DemoPage1());
			this.Children.Add(new DemoPage2());
			this.Children.Add(new DemoPage3());
		}
	}
}
