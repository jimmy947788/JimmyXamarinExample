using System;
using SQLite;
using SQliteDemo.Interface;
using SQliteDemo.Models;
using Xamarin.Forms;

namespace SQliteDemo
{
	public partial class SQliteDemoPage : ContentPage
	{
		SQLiteConnection sqlite;
		public SQliteDemoPage()
		{
			InitializeComponent();

			var myDocPath =
				DependencyService.Get<IFolder>().GetMyDocumentPath();
			var databasePath = System.IO.Path.Combine(myDocPath, "local.db3");
			sqlite = new SQLiteConnection(databasePath);

			//var profiles = sqlite.Query<Profile>("");

			var setting1 = sqlite.Get<Profile>(1);
			settingEntry1.Label = setting1.Display;
			settingEntry1.Text = setting1.Value;

			var setting2 = sqlite.Get<Profile>(2);
			settingEntry2.Label = setting2.Display;
			settingEntry2.Text = setting2.Value;

			var setting3 = sqlite.Get<Profile>(3);
			settingEntry3.Label = setting3.Display;
			settingEntry3.Text = setting3.Value;
		}

		void Save_Clicked(object sender, EventArgs e)
		{
			sqlite.Update(new Profile
			{
				Key = 1,
				Display = settingEntry1.Label,
				Value = settingEntry1.Text
			});

			sqlite.Update(new Profile
			{
				Key = 2,
				Display = settingEntry2.Label,
				Value = settingEntry2.Text
			});

			sqlite.Update(new Profile
			{
				Key = 3,
				Display = settingEntry3.Label,
				Value = settingEntry3.Text
			});

		}
	}
}
