using System;
using System.Linq;
using ＭvvmDemo.Service;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using ＭvvmDemo.Models;
using System.Diagnostics;
using MvvmHelpers;

namespace ＭvvmDemo.ViewModels
{
	public class MasterViewModel : MvvmHelpers.BaseViewModel
	{
		ActorService actorService;
		public MasterViewModel()
		{
			Title = "Tokyo-Hot";
			actorService = new ActorService();
			details = new ObservableRangeCollection<DetailViewModel>();
			LoadData();

			ItemTappedCommand = new Command((obj) =>
			{
				var actor = obj as Actor;
				Debug.WriteLine("{0} was tapped.", actor.Name);

				var detailViewModel = Details
								.Where(d => d.Actor.ID == actor.ID)
								.Select(d => d)
								.Single();
				var mainPage = App.Current.MainPage;
				var navgation = mainPage.Navigation;
				navgation.PushAsync(new Views.DetailPage(detailViewModel));
			});
		}

		void LoadData()
		{
			foreach (var actor in actorService.GetAll().Take(5))
			{
				details.Add(new DetailViewModel(actor.Name)
				{
					Actor = actor
				});
			}

			Device.StartTimer(TimeSpan.FromSeconds(5), () =>
			{
				var aaaa = new List<DetailViewModel>();
				foreach (var actor in actorService.GetAll().Skip(5))
				{
					aaaa.Add(new DetailViewModel(actor.Name)
					{
						Actor = actor
					});
				}
				details.AddRange(aaaa);

				return false;
			});
		}
		ObservableRangeCollection<DetailViewModel> details;
		public IList<DetailViewModel> Details
		{
			get { return this.details; }
		}

		public IList<Grouping<string, DetailViewModel>> GroupDetails
		{
			get
			{
				return (from detail in details
						orderby detail.Actor.Sign
						group detail by detail.Actor.Sign into actorGroup
						select new Grouping<string, DetailViewModel>(actorGroup.Key, actorGroup))
					  .ToList();
			}
		}

		public ICommand ItemTappedCommand { get; private set; }
	}
}
