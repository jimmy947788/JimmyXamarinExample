using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SQLite;
using SQliteDemo.Interface;
using SQliteDemo.Models;
using SQLiteDemo.Interface;
using SQLiteDemo.Models;
using Xamarin.Forms;
using XLabs.Ioc;

namespace SQliteDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//var myDocPath =
			//	DependencyService.Get<IFolder>().GetMyDocumentPath();
			//var databasePath = System.IO.Path.Combine(myDocPath, "local.db3");
			//Debug.WriteLine("databasePath:{0}", databasePath);

			//var sqlite =
			//	new SQLiteConnection(databasePath);

			//string sqlcmd = 
			//	"SELECT Count(*) FROM sqlite_master WHERE type='table' AND name=?";
			//var result = sqlite.ExecuteScalar<int>(sqlcmd, "Profile");
			//if (result == 0)
			//{
			//	IList<Profile> profiles = new List<Profile>();
			//	profiles.Add(new Profile()
			//	{
			//		Display = "電話",
			//		Key = 1,
			//		Value = "09XX123456"
			//	});
			//	profiles.Add(new Profile()
			//	{
			//		Display = "Email",
			//		Key = 2,
			//		Value = "jimmy.wu@daedalus.com.tw"
			//	});
			//	profiles.Add(new Profile()
			//	{
			//		Display = "暱稱",
			//		Key = 3,
			//		Value = "jimmy wu"
			//	});

			//	int ret = sqlite.CreateTable<Profile>();
			//	sqlite.InsertAll(profiles);
			//}

			IActorRepository actorRepository = 
				Resolver.Resolve<IActorRepository>();

			actorRepository.DeleteAll();
			actorRepository.InsertAll(LoadData());


			MainPage = new NavigationPage(new ListViewPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
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
				Photo = "A0001.jpg"
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
				Photo = "A0002.jpg"
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
				Photo = "A0003.jpg"
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
				Photo = "A0004.jpg"
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
				Photo = "A0005.jpg"
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
				Photo = "A0006.jpg"
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
				Photo = "A0007.jpg"
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
				Photo = "A0008.jpg"
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
				Photo = "A0009.jpg"
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
				Photo = "A0011.jpg"
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
				Photo = "A0012.jpg"
			});

			return actors;
		}
		#endregion
	}
}
