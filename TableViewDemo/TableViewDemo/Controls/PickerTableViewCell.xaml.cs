using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TableViewDemo.Controls
{
	public partial class PickerTableViewCell : TableViewCell
	{
		public PickerTableViewCell()
		{
			InitializeComponent();
			BindingContext = this;
			Text = "請選擇";
		}

		void PickerTableViewCell_Tapped(object sender, EventArgs e)
		{
			picker.Focus();
		}

		void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Text = picker.Items[picker.SelectedIndex];
		}

		#region "Custom Bindable Property [Items]"
		public static readonly BindableProperty ItemsProperty =
			BindableProperty.Create(
				"Items",
				typeof(IList<string>),
				typeof(PickerTableViewCell),
				new List<string>()
			);

		public IList<string> Items
		{
			set { SetValue(ItemsProperty, value); }
			get { return (IList<string>)GetValue(ItemsProperty); }
		}
		#endregion

		protected override void OnParentSet()
		{
			base.OnParentSet();

			if (Items.Count > 0)
			{
				picker.Items.Clear();
				foreach (var item in Items)
				{
					picker.Items.Add(item);
				}

			}
		}
	}
}
