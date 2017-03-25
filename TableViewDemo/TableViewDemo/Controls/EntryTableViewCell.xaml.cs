using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TableViewDemo.Controls
{
	public partial class EntryTableViewCell : TableViewCell
	{
		public EntryTableViewCell()
		{
			InitializeComponent();
			BindingContext = this;
		}
	}
}
