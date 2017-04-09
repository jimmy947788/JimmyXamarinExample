using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using WebViewDemo.Interface;
using Xamarin.Forms;

namespace WebViewDemo
{
	public partial class WebViewDemoPage : ContentPage
	{
		void Handle_Navigating(object sender, Xamarin.Forms.WebNavigatingEventArgs e)
		{
			activityIndicator.IsRunning = true;
		}

		void Handle_Navigated(object sender, Xamarin.Forms.WebNavigatedEventArgs e)
		{
			activityIndicator.IsRunning = false;

			//var name = "Jimmy";
			//webView.Eval(string.Format("JsSayHello('{0}')", name));
			//webView.Eval("CreateChart([ 200, 100, 300]);");
		}

		public WebViewDemoPage()
		{
			InitializeComponent();

			//var source = new UrlWebViewSource()

			var resourceId = "WebViewDemo.Resource.Chart.html";
			var assembly = typeof(WebViewDemoPage).GetTypeInfo().Assembly;
			var html = string.Empty;
			using(Stream stream = assembly.GetManifestResourceStream(resourceId))
			using (var reader = new System.IO.StreamReader(stream)) {
			    html = reader.ReadToEnd ();
				Debug.WriteLine("html:{0}", html);
			}

			var baseUrl = DependencyService.Get<IBaseUrl>().Get();
			var source = new HtmlWebViewSource();
			source.BaseUrl = baseUrl;
			source.Html = html;
			webView.Source = source;
		}
	}
}
