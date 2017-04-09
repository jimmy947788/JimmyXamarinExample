using System;
using Xamarin.Forms;
using WebViewDemo.Droid.DService;
using WebViewDemo.Interface;

[assembly : Dependency(typeof(BaseUrl))]
namespace WebViewDemo.Droid.DService
{
	public class BaseUrl : IBaseUrl
	{
		public string Get()
		{
			return "file:///android_asset/";
		}
	}
}
