using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NavigationDemo.Controls
{
	public partial class NavigationBarView : ContentView
	{
		void Handle_Tapped(object sender, System.EventArgs e)
		{
			Navigation.PopAsync();
		}

		public NavigationBarView()
		{
			InitializeComponent();
		}


		//string title;
		//public string Title
		//{
		//	get { return this.title; }
		//	set
		//	{
		//		this.title = value;
		//		lblTitle.Text = value;
		//	}
		//}

		public static readonly BindableProperty TitleProperty =
			BindableProperty.Create(
				"Title",
				typeof(string),
				typeof(NavigationBarView),
				"this is Title",
				propertyChanged: OnTitlePropertyChanged
			);
		public string Title
		{
			get { return (string)GetValue(TitleProperty); }
			set { SetValue(TitleProperty, value); }
		}

		static void OnTitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as NavigationBarView;
			var title = newValue.ToString();
			thisView.lblTitle.Text = title;
		}
	}
}
