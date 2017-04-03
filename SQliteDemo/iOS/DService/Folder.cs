using System;
using SQliteDemo.Interface;
using SQliteDemo.iOS.DService;

[assembly: Xamarin.Forms.Dependency(typeof(Folder))]
namespace SQliteDemo.iOS.DService
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
