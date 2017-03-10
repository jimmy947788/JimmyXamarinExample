using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ScrollViewDemo.Controls
{
	public partial class HMenuView : ContentView
	{
		public HMenuView()
		{
			InitializeComponent();
		}

		public event EventHandler<HMenuItemSelectdEventArgs> ItemSelectd;
		public void NotifyItemSelected(HMenuItemView item)
		{
			foreach (HMenuItemView child in slMenuItems.Children)
			{
				child.Selected = false;
				if (child.Text == item.Text)
				{
					child.Selected = true;
					if (ItemSelectd != null)
					{
						ItemSelectd(ItemSelectd, new HMenuItemSelectdEventArgs(item.Text, item.Value));
					}
				}
			}
		}

		#region "Custom Bindable Property [Items]"
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create(
				"Items",
				typeof(IList<HMenuItem>),
				typeof(HMenuView),
				null,
				propertyChanged : OnItemsPropertyChanged
			);
		public IList<HMenuItem> Items
		{
			set { SetValue(ItemsProperty, value); }
			get { return (IList<HMenuItem>)GetValue(ItemsProperty); }
		}

		private static void OnItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var thisView = bindable as HMenuView;
			var category = newValue as IList<HMenuItem>;
			if (category != null)
			{
				thisView.slMenuItems.Children.Clear();
				foreach (var item in category)
				{
					var horizontalMenuItemView = new HMenuItemView()
					{
						Text = item.Text,
						Value = item.Value.ToString(),
						Selected = item.Selected,
					};

					horizontalMenuItemView.ItemSelected += (sender, e) => {
						thisView.NotifyItemSelected(horizontalMenuItemView);
					};
					thisView.slMenuItems.Children.Add(horizontalMenuItemView);
				}
			}
		}
		#endregion
	}
}
