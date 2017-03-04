using System.Diagnostics;
using Xamarin.Forms;

namespace MasterDetailDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			menu.IsPresented = true;
		}

		#region "pan for show menu"
		double startX, startY, endX, endY;
		void OnPanUpdated(object sender, PanUpdatedEventArgs e)
		{
			Debug.WriteLine("x:{0}, y:{1}", e.TotalX, e.TotalY);
			// Handle the pan
			if (e.StatusType == GestureStatus.Started)
			{
				Debug.WriteLine("GestureStatus.Started");
				startX = e.TotalX;
				startY = e.TotalY;
			}

			if (e.StatusType == GestureStatus.Running)
			{
				Debug.WriteLine("GestureStatus.Running");
				endX = e.TotalX;
				endY = e.TotalY;
			}

			if (e.StatusType == GestureStatus.Completed)
			{
				Debug.WriteLine("GestureStatus.Completed");
				if (endX > startX)
				{
					menu.IsPresented = true;
				}
				startX = startY = endX = endY = 0;
			}
		}
		#endregion

		#region "Select menu item"
		void Handle_ItemSelectd(object sender, MasterDetailDemo.Controls.SideMenuViewItemSelectdEventArg e)
		{
			var filename = e.Text.Replace('-', '_') + ".jpg";
			imgAIKA.Source = ImageSource.FromFile(filename );
			menu.IsPresented = false;
		}
  		#endregion
	}
}
