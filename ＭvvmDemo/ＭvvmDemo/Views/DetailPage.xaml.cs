using System;
using System.Collections.Generic;
using ＭvvmDemo.ViewModels;
using Xamarin.Forms;

namespace ＭvvmDemo.Views
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage(DetailViewModel detailViewModel)
		{
			InitializeComponent();
			BindingContext = detailViewModel;
		}
	}
}
