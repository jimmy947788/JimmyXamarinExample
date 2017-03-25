using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace TableViewDemo.Controls
{
	public partial class SwitchButton : ContentView
	{
		public SwitchButton()
		{
			InitializeComponent();
		}

		#region "Custom Bindable Property [IsToggled]"
		public static readonly BindableProperty IsToggledProperty =
			BindableProperty.Create(
				"IsToggled",
				typeof(bool),
				typeof(SwitchButton),
				false
			);

		public bool IsToggled
		{
			set
			{
				SetValue(IsToggledProperty, value);
				UpdateView();
				if (Toggled != null)
				{
					Toggled(this, new EventArgs());
				}
			}
			get { return (bool)GetValue(IsToggledProperty); }
		}
		#endregion

		public event EventHandler Toggled;
		void SwitchButton_Tapped(object sender, System.EventArgs e)
		{
			IsToggled = !IsToggled;
		}

		void UpdateView()
		{
			double newX = 1;
			if (IsToggled)
			{
				imgBG.Source = "swbtn_green_background.png";
				newX = rlFrame.X + 29;
			}
			else
			{
				imgBG.Source = "swbtn_white_background.png";
				newX = rlFrame.X + 1;
			}

			var rect = new Rectangle(newX, imgThumb.Y, imgThumb.Width, imgThumb.Height);
			imgThumb.LayoutTo(rect, 100);

			Debug.WriteLine("IsToggled : {0}", IsToggled);
		}
	}
}
