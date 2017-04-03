using System;
using System.Collections.Generic;
using SQLiteDemo.Models;
using Xamarin.Forms;

namespace SQliteDemo
{
	public partial class ViewPage : ContentPage
	{
		public ViewPage(Actor actor)
		{
			InitializeComponent();

			Title = actor.Name;
			webview.Source = 
				string.Format("http://www.tokyo-hot.com/cast/{0}/", actor.ID);
		}
	}
}
