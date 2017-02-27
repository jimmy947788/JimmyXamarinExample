using System.Diagnostics;
using Xamarin.Forms;

namespace EntryDemo
{
	public partial class MainPage : ContentPage
	{
		void Handle_Completed(object sender, System.EventArgs e)
		{
			var entry = sender as Entry;
			Debug.WriteLine("the input is : {0}", entry.Text);
		}

		void Handle_TextChanged(object sender, 
		                        Xamarin.Forms.TextChangedEventArgs e)
		{
			Debug.WriteLine("the input is : {0}", e.NewTextValue);
		}

		public MainPage()
		{
			InitializeComponent();
		}
	}
}
