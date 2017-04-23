using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlideUnlockDemo
{
	public partial class SlideUnlockDemoPage : ContentPage
	{
		void Handle_Unlock(object sender, System.EventArgs e)
		{
			Debug.WriteLine("======> Unlock !!!");
			
		}

		public SlideUnlockDemoPage()
		{
			InitializeComponent();
		}
	}
}
