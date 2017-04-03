using System;
using SQliteDemo.Droid.DService;
using SQliteDemo.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(Folder))]
namespace SQliteDemo.Droid.DService
{
	public class Folder : IFolder
	{
		public string GetMyDocumentPath()
		{
			return Environment.GetFolderPath(
				Environment.SpecialFolder.MyDocuments);
		}
	}
}
