using System;
using System.Collections.Generic;
using SQLiteDemo.Interface;
using SQLiteDemo.Models;
using Xamarin.Forms;
using XLabs.Ioc;

namespace SQliteDemo
{
	public partial class AddPage : ContentPage
	{
		IActorRepository actorRepository;
		public AddPage()
		{
			InitializeComponent();

			actorRepository = Resolver.Resolve<IActorRepository>();
			BindingContext = new Actor();
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			var actor = BindingContext as Actor;
			actorRepository.Insert(actor);
			await Navigation.PopAsync();
		}
	}
}
