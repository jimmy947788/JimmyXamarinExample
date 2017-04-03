using System;
using System.Collections.Generic;
using SQLiteDemo.Interface;
using SQLiteDemo.Models;
using Xamarin.Forms;
using XLabs.Ioc;

namespace SQliteDemo
{
	public partial class ListViewPage : ContentPage
	{
		IActorRepository actorRepository;
		public ListViewPage()
		{
			InitializeComponent();

			ToolbarItems.Add(new ToolbarItem("Add", "", async () =>
			{
				await Navigation.PushAsync(new AddPage());
			}));

			actorRepository = Resolver.Resolve<IActorRepository>();
		}

		protected override void OnAppearing()
		{
			listview.ItemsSource = actorRepository.GetAll();
			base.OnAppearing();
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var actor = e.Item as Actor;
			await Navigation.PushAsync(new ViewPage(actor));
		}

		async void Edit_Clicked(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			var actor = mi.CommandParameter as Actor;

			await Navigation.PushAsync(new EditPage(actor));
		}

		void Delete_Clicked(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			var actor = mi.CommandParameter as Actor;

			actorRepository.Delete(actor);
			listview.ItemsSource = actorRepository.GetAll();

		}
	}
}
