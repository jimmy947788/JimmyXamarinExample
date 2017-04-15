using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace FileSystemDemo
{
	public partial class FileSystemDemoPage : ContentPage
	{
	 	public FileSystemDemoPage()
		{
			InitializeComponent();
		}

		 async void Handle_Clicked(object sender, System.EventArgs e)
		{
			IFolder rootFolder = FileSystem.Current.LocalStorage;

			IFolder folder = await rootFolder.CreateFolderAsync("Temp", CreationCollisionOption.OpenIfExists);

			IFile file = await folder.CreateFileAsync("MyTest.txt", CreationCollisionOption.OpenIfExists);
			lblMessage.Text =  await file.ReadAllTextAsync();
		}
	}
}
