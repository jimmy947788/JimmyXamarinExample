using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TableViewDemo.Controls
{
	public partial class Button : ContentView
	{
		public Button()
		{
			InitializeComponent();
		}

		#region "Custom Bindable Property [Text]"
		public static readonly BindableProperty TextProperty =
			BindableProperty.Create(
				"Text",
				typeof(string),
				typeof(Button),
				"",
				propertyChanged: OnTextPropertyChanged
			);

		public string Text
		{
			set { SetValue(TextProperty, value); }
			get { return (string)GetValue(TextProperty); }
		}

		private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as Button;
			thisView.lblText.Text = newValue.ToString();
		}
		#endregion

		public event EventHandler Tapped;
		void Button_Tapped(object sender, EventArgs e)
		{
			if (Tapped != null)
			{
				Tapped(this, EventArgs.Empty);
			}
		}
	}
}
