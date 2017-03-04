using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MasterDetailDemo.Controls
{
	public class SideMenuViewItemSelectdEventArg : EventArgs
	{
		string text;
		public SideMenuViewItemSelectdEventArg(string text)
		{
			this.text = text;
		}
		public string Text
		{
			get { return text; }
		}
	}
	public partial class SideMenuView : ContentView
	{
		public SideMenuView()
		{
			InitializeComponent();
			HideMenu();
		}

		double parentViewHeight;
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			if (height > 0)
			{
				parentViewHeight = height;
				Debug.WriteLine("parentViewHeight:{0}", parentViewHeight);
			}
		}

		const double MENU_WIDTH = 200;
		void OnHideMenuTapped(object sender, System.EventArgs e)
		{
			IsPresented = false;
		}

		public static readonly BindableProperty IsPresentedProperty =  
			BindableProperty.Create(
				"IsPresented",
				typeof(bool),
				typeof(SideMenuView),
				false);
		
		public bool IsPresented
		{
			get { return (bool)GetValue(IsPresentedProperty); }
			set
			{
				if (IsPresented == value)
					return;

				SetValue(IsPresentedProperty, value);

				if (value)
					ShowMenu();
				else
					HideMenu();
			}
		}

		private async void ShowMenu()
		{
			Debug.WriteLine("ShowMenu");

			// 1.show this control
			this.IsVisible = true;

			// 2.show gray Overlay
			grayOverlay.IsVisible = true;

			// 3.show meun
			var rectMenu = menu.Bounds;
		 	await menu.LayoutTo(new Rectangle(0, rectMenu.Y, MENU_WIDTH, parentViewHeight));

			// 4. show menu shadow
			menuShadow.IsVisible = true;
			menuShadow.LayoutTo(new Rectangle(rectMenu.Width, rectMenu.Y, 3, parentViewHeight));
		}
		private async void HideMenu()
		{
			// 1.hide menu shadow
			menuShadow.IsVisible = false;
			menuShadow.LayoutTo(new Rectangle(0, 0, 3, parentViewHeight));

			// 2.hide menu		
			var rectMenu = menu.Bounds;
			await menu.LayoutTo(new Rectangle(rectMenu.X - MENU_WIDTH, rectMenu.Y, MENU_WIDTH, parentViewHeight));

			// 3.hide gray Overlay
			grayOverlay.IsVisible = false;

			// 4.hide this control
			this.IsVisible = false;
		}

		public event EventHandler<SideMenuViewItemSelectdEventArg> ItemSelectd;
		protected void OnItemSelected(object sender, System.EventArgs e)
		{
			var label = sender as Label;
			Debug.WriteLine(label.Text);
			if (ItemSelectd != null)
			{
				ItemSelectd(this, new SideMenuViewItemSelectdEventArg(label.Text));
			}
		}
	}
}
