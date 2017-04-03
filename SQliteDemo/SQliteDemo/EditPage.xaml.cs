using System;
using System.Collections.Generic;
using SQLiteDemo.Interface;
using SQLiteDemo.Models;
using Xamarin.Forms;
using XLabs.Ioc;

namespace SQliteDemo
{
	public partial class EditPage : ContentPage
	{
		IActorRepository actorRepository;
		public EditPage(Actor actor)
		{
			InitializeComponent();
			Title = actor.Name;

			actorRepository = Resolver.Resolve<IActorRepository>();
			BindingContext = actor;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
			var actor = BindingContext as Actor;
			actorRepository.Update(actor);
			await Navigation.PopAsync();
		}
	}
}
