using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TableViewDemo.Controls
{
	public partial class SwitchTableViewCell : TableViewCell
	{
		public SwitchTableViewCell()
		{
			InitializeComponent();
		}

		public bool IsToggled
		{
			get { return switchButton.IsToggled; }
			set { switchButton.IsToggled = value; }
		}
	}
}
