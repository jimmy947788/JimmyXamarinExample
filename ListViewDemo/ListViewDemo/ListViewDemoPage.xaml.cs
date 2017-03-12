using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using ListViewDemo.Controls;
using ListViewDemo.Models;
using ListViewDemo.ViewModels;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ListViewDemo
{
	public partial class ListViewDemoPage : ContentPage
	{
		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			listView.SelectedItem = null;
		}

		public ListViewDemoPage()
		{
			InitializeComponent();
			//listView.ItemsSource = LoadData();

			var source = from actor in LoadData()
						 orderby actor.Name
						 group actor by actor.Sign into actorGroup
						 select new Grouping<string, Actor>(actorGroup.Key, actorGroup);
			listView.ItemsSource = source;

		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			var actor = e.Item as Actor;
			//Navigation.PushAsync(new DetailPage(actor.ID, actor.Name));
		}

		async void Handle_Refreshing(object sender, System.EventArgs e)
		{
			await Task.Delay(5000);
			listView.IsRefreshing = false;
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
