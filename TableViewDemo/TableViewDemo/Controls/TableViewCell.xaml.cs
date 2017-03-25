using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TableViewDemo.Controls
{
	public partial class TableViewCell : ContentView
	{
		public TableViewCell()
		{
			InitializeComponent();
		}

		#region "Custom Bindable Property [Label]"
		public static readonly BindableProperty LabelProperty =
			BindableProperty.Create(
				"Label",
				typeof(string),
				typeof(TableViewCell),
				"LabelText",
				propertyChanged: OnLabelPropertyChanged
			);

		public string Label
		{
			set { SetValue(LabelProperty, value); }
			get { return (string)GetValue(LabelProperty); }
		}

		private static void OnLabelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as TableViewCell;
			thisView.lblLabel.Text = newValue.ToString();
		}
		#endregion

		#region "Custom Bindable Property [LabelColor]"
		public static readonly BindableProperty LabelColorProperty =
			BindableProperty.Create(
				"LabelColor",
				typeof(Color),
				typeof(TableViewCell),
				Color.Black,
				propertyChanged: OnLabelColorPropertyChanged
			);

		public Color LabelColor
		{
			set { SetValue(LabelColorProperty, value); }
			get { return (Color)GetValue(LabelColorProperty); }
		}

		private static void OnLabelColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as TableViewCell;
			thisView.lblLabel.TextColor = (Color)newValue;
		}
		#endregion

		#region "Custom Bindable Property [Text]"
		public static readonly BindableProperty TextProperty =
			BindableProperty.Create(
				"Text",
				typeof(string),
				typeof(TableViewCell),
				"this is text",
				propertyChanged: OnTextPropertyChanged
			);

		public string Text
		{
			set { SetValue(TextProperty, value); }
			get { return (string)GetValue(TextProperty); }
		}

		private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as TableViewCell;
			thisView.lblText.Text = newValue.ToString();
		}
		#endregion

		#region "Custom Bindable Property [IsBottom]"
		public static readonly BindableProperty IsBottomProperty =
			BindableProperty.Create(
				"IsBottom",
				typeof(bool),
				typeof(TableViewCell),
				false,
				propertyChanged: OnIsBottomPropertyChanged
			);

		public bool IsBottom
		{
			set { SetValue(IsBottomProperty, value); }
			get { return (bool)GetValue(IsBottomProperty); }
		}

		private static void OnIsBottomPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as TableViewCell;
			var isBottom = Convert.ToBoolean(newValue);
			thisView.bvBottom1.IsVisible = !isBottom;
			thisView.bvBottom2.IsVisible = isBottom;
		}
		#endregion

		#region "Custom Bindable Property [Placeholder]"
		public static readonly BindableProperty PlaceholderProperty =
			BindableProperty.Create(
				"Placeholder",
				typeof(View),
				typeof(TableViewCell),
				null
			);

		public View Placeholder
		{
			set { SetValue(PlaceholderProperty, value); }
			get { return (View)GetValue(PlaceholderProperty); }
		}
		#endregion

		protected override void OnParentSet()
		{
			base.OnParentSet();
			if (Placeholder != null)
			{
				this.cvPlaceholder.Content = Placeholder;
			}
		}
	}
}
