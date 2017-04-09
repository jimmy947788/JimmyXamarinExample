using System;
using Foundation;
using WebViewDemo.Interface;
using WebViewDemo.iOS.DService;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace WebViewDemo.iOS.DService
{
	public class BaseUrl : IBaseUrl
	{
		public string Get()
		{
			return NSBundle.MainBundle.BundlePath;
		}	
	}
}
