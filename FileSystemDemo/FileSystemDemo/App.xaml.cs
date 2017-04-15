using System.Diagnostics;
using PCLStorage;
using Xamarin.Forms;

namespace FileSystemDemo
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new FileSystemDemoPage();
			//MainPage = new DownloadImagePage();
		}

		protected override async void OnStart()
		{
			// Handle when your app starts
			IFolder rootFolder = FileSystem.Current.LocalStorage;
			Debug.WriteLine($"Root Flder name :{rootFolder.Name}");
			Debug.WriteLine($"Root Flder path :{rootFolder.Path}");

			IFolder folder = await rootFolder.CreateFolderAsync("Temp", CreationCollisionOption.OpenIfExists);
			Debug.WriteLine($"Temp Flder name :{folder.Name}");
			Debug.WriteLine($"Temp Flder path :{folder.Path}");

			IFile file = await folder.CreateFileAsync("MyTest.txt", CreationCollisionOption.OpenIfExists);
			await file.WriteAllTextAsync("Hello I'm Jimmy");
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
