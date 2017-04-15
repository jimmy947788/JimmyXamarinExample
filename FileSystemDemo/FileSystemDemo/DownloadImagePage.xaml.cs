using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace FileSystemDemo
{
	public partial class DownloadImagePage : ContentPage
	{
		public DownloadImagePage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

            DownloadLocalStorage();
		}

		async Task DownloadLocalStorage()
		{

			IFolder rootFolder = FileSystem.Current.LocalStorage;
			Debug.WriteLine($"Root Flder name :{rootFolder.Name}");
			Debug.WriteLine($"Root Flder path :{rootFolder.Path}");

			IFolder folder = await rootFolder.CreateFolderAsync("temp", CreationCollisionOption.OpenIfExists);
			Debug.WriteLine($"MySubFolder Flder name :{folder.Name}");
			Debug.WriteLine($"MySubFolder Flder path :{folder.Path}");

			var filename = "zd861_5.jpg";
			var rrr = await folder.CheckExistsAsync(filename);
			if (rrr == ExistenceCheckResult.FileExists)
				Debug.WriteLine($"{filename} is exists");
			if (rrr == ExistenceCheckResult.NotFound)
				Debug.WriteLine($"{filename} is not fount");

			IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

			var client = new HttpClient();
			using (var jpg = await client.GetStreamAsync("http://img31.otofotki.pl/obrazki/zd861_5.jpg"))
			{
				// populate the file with some text
				using (var filestream = await file.OpenAsync(FileAccess.ReadAndWrite))
				{
					jpg.CopyTo(filestream);
					image.Source = file.Path;
					activityIndicator.IsRunning = false;
				}
			}
		}
	}
}
