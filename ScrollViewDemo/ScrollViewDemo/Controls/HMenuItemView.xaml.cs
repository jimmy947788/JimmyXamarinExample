using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ScrollViewDemo.Controls
{
	public partial class HMenuItemView : ContentView
	{
		public HMenuItemView()
		{
			InitializeComponent();
		}

		#region "Custom Bindable Property [Text]"
		private static readonly BindableProperty TextProperty =
			BindableProperty.Create(
				"Text",
				typeof(string),
				typeof(HMenuItemView),
				null,
				propertyChanged: OnTextChanged
			);

		public string Text
		{
			set { SetValue(TextProperty, value); }
			get { return (string)GetValue(TextProperty); }
		}

		private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var horizontalMenuItemView = bindable as HMenuItemView;
			horizontalMenuItemView.lblText.Text = newValue.ToString();
		}
		#endregion

		#region "Custom Bindable Property [Value]"
		private static readonly BindableProperty ValueProperty =
			BindableProperty.Create(
				"Value",
				typeof(string),
				typeof(HMenuItemView),
				null
			);

		public string Value
		{
			set { SetValue(ValueProperty, value); }
			get { return (string)GetValue(ValueProperty); }
		}
		#endregion

		#region "Custom Bindable Property [Selected]"
		private static readonly BindableProperty SelectedProperty =
			BindableProperty.Create(
				"Selected",
				typeof(bool),
				typeof(HMenuItemView),
				false,
				propertyChanged: OnSelectedChanged
			);

		public bool Selected
		{
			set { SetValue(SelectedProperty, value); }
			get { return (bool)GetValue(SelectedProperty); }
		}

		private static void OnSelectedChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var horizontalMenuItemView = bindable as HMenuItemView;
			var selected = (bool)newValue;

			if (selected)
			{
				horizontalMenuItemView.lblText.TextColor = Color.FromHex("#3EACE9");
				horizontalMenuItemView.bvBottom.BackgroundColor = Color.FromHex("#0AADFF");
			}
			else
			{
				horizontalMenuItemView.lblText.TextColor = Color.FromHex("#3A3A3A");
				horizontalMenuItemView.bvBottom.BackgroundColor = Color.Transparent;
			}
		}
		#endregion

		public event EventHandler<HMenuItemSelectdEventArgs> ItemSelected;
		protected void MenuItem_Tapped(object sender, EventArgs arg)
		{
			if (ItemSelected != null)
			{
				ItemSelected(this, new HMenuItemSelectdEventArgs(Text, Value)); 
			}
		}
	}
}
