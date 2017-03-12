using System;
using System.Diagnostics;
using System.Windows.Input;
using ListViewDemo.Models;
using Xamarin.Forms;

namespace ListViewDemo.ViewModels
{
	public class TwoColumnsViewModel
	{
		public TwoColumnsViewModel()
		{
			this.ItemTapCommand = new Command<Actor>((actor) =>
			{
				// Add the key to the input string.
				Debug.WriteLine("Item tap id:{0}", actor.ID);

				Navigation.PushAsync(new DetailPage(actor.ID, actor.Name));
			});

		}

		public Actor RightColumn { get; set; }
		public Actor LeftColumn { get; set; }

		public ICommand ItemTapCommand { get; private set; }

		public INavigation Navigation { get; set; }
	}
}
