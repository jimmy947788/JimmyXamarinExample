using System;
using System.Linq;
using System.Collections.Generic;
using ListViewDemo.ViewModels;
using Xamarin.Forms;
using ListViewDemo.Models;
using System.Collections;
using System.Diagnostics;

namespace ListViewDemo
{
	public partial class TwoColumDemoPage : ContentPage
	{
		public TwoColumDemoPage()
		{
			InitializeComponent();

			//listView.ItemsSource = ConvertToTwoColumnsViewModelCollection(LoadData());

			var datasource = LoadData()
									 .Take(listView.PageSize * 2)
									 .ToList();
			listView.ItemsSource = ConvertToTwoColumnsViewModelCollection(datasource);
		}

		IList<TwoColumnsViewModel> ConvertToTwoColumnsViewModelCollection(IList<Actor> actors)
		{
			var dataSource = new List<TwoColumnsViewModel>();
			for (var i = 0; i <= actors.Count - 1; i += 2)
			{
				var hasRight = (i + 1) < actors.Count;
				dataSource.Add(new TwoColumnsViewModel
				{
					LeftColumn = actors[i],
					RightColumn = hasRight ? actors[i + 1] : null,
					Navigation = Navigation
				});
			}

			return dataSource;
		}
		

		void Handle_LoadMore(object sender, ListViewDemo.Controls.ListViewExLoadMoreEventArgs e)
		{
			var totalCount = (listView.ItemsSource as IList).Count;
			var itemCount = (LoadData().Count / 2) +
				(LoadData().Count % 2);
			if (itemCount == totalCount)
			{
				Debug.WriteLine("No more data!!");
				return;
			}
			var datasource = LoadData()
	                         .Take((listView.PageSize * 2) * (e.CurrentIndex + 1))
							 .ToList();
			listView.ItemsSource = ConvertToTwoColumnsViewModelCollection(datasource);
			Debug.WriteLine("Current Page is {0}", (e.CurrentIndex + 1));
		}

		#region "LoadData"
		protected IList<Actor> LoadData()
		{
			var actors = new List<Actor>();
			actors.Add(new Actor
			{
				ID = 5974,
				Name = "杏樹紗奈",
				Height = "150cm ~ 154cm",
				BreastType = "大乳",
				BodyType = "スレンダー",
				Cup = "E",
				Bust = "85cm ~ 89cm",
				Waist = "55cm ~ 59cm",
				Hip = "80cm ~ 84cm",
				BloodType = "O型",
				Sign = "山羊座",
				Photo = ImageSource.FromFile("A0001.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6196,
				Name = "愛咲れいら",
				Height = "170cm以上",
				BreastType = "中乳",
				BodyType = "スレンダー",
				Cup = "C",
				Bust = "85cm ~ 89cm",
				Waist = "55cm ~ 59cm",
				Hip = "85cm ~ 89cm",
				BloodType = "B型",
				Sign = "牡羊座",
				Photo = ImageSource.FromFile("A0002.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6138,
				Name = "愛花沙也",
				Height = "155cm ~ 159cm",
				BreastType = "中乳",
				BodyType = "スレンダー",
				Cup = "D",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "85cm ~ 89cm",
				BloodType = "A型",
				Sign = "射手座",
				Photo = ImageSource.FromFile("A0003.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6199,
				Name = "荒木まい",
				Height = "155cm ~ 159cm",
				BreastType = "中乳",
				BodyType = "ちび炉利系",
				Cup = "D",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "85cm ~ 89cm",
				BloodType = "A型",
				Sign = "牡牛座",
				Photo = ImageSource.FromFile("A0004.jpg")
			});

			actors.Add(new Actor
			{
				ID = 5985,
				Name = "明日香クレア",
				Height = "165cm ~ 169cm",
				BreastType = "中乳",
				BodyType = "普通",
				Cup = "C",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "85cm ~ 89cm",
				BloodType = "O型",
				Sign = "蟹座",
				Photo = ImageSource.FromFile("A0005.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6140,
				Name = "足立まりえ",
				Height = "150cm ~ 154cm",
				BreastType = "中乳",
				BodyType = "ちび炉利系",
				Cup = "B",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "85cm ~ 89cm",
				BloodType = "O型",
				Sign = "蟹座",
				Photo = ImageSource.FromFile("A0006.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6961,
				Name = "安成愛海",
				Height = "155cm ~ 159cm",
				BreastType = "中乳",
				BodyType = "普通",
				Cup = "A",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "80cm ~ 84cm",
				BloodType = "A型",
				Sign = "天秤座",
				Photo = ImageSource.FromFile("A0007.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6247,
				Name = "朝倉なつ",
				Height = "149cm以下",
				BreastType = "大乳",
				BodyType = "普通",
				Cup = "F",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "80cm ~ 84cm",
				BloodType = "A型",
				Sign = "蟹座",
				Photo = ImageSource.FromFile("A0008.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6505,
				Name = "青木祐美",
				Height = "150cm ~ 154cm",
				BreastType = "大乳",
				BodyType = "普通",
				Cup = "F",
				Bust = "90cm以上",
				Waist = "55cm ~ 59cm",
				Hip = "85cm ~ 89cm",
				BloodType = "B型",
				Sign = "蟹座",
				Photo = ImageSource.FromFile("A0009.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6268,
				Name = "相崎琴音",
				Height = "165cm ~ 169cm",
				BreastType = "中乳",
				BodyType = "普通",
				Cup = "C",
				Bust = "80cm ~ 84cm",
				Waist = "55cm ~ 59cm",
				Hip = "80cm ~ 84cm",
				BloodType = "B型",
				Sign = "天秤座",
				Photo = ImageSource.FromFile("A0011.jpg")
			});

			actors.Add(new Actor
			{
				ID = 6273,
				Name = "AYU",
				Height = "155cm ~ 159cm",
				BreastType = "大乳",
				BodyType = "スレンダー",
				Cup = "E",
				Bust = "90cm以上",
				Waist = "55cm ~ 59cm",
				Hip = "80cm ~ 84cm",
				BloodType = "A型",
				Sign = "蟹座",
				Photo = ImageSource.FromFile("A0012.jpg")
			});

			return actors;
		}
		#endregion
	}
}
