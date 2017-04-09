using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using WebViewDemo.Interface;
using Xamarin.Forms;

namespace WebViewDemo
{
	public partial class HybirdWebViewPage : ContentPage
	{
		public HybirdWebViewPage()
		{
			InitializeComponent();
			webview.LoadFinished += (sender, e) => {
				webview.CallJsFunction("JsSayHello", "Jimmy");
			};

			 webview.RegisterCallback(
				"dataCallback", t => System.Diagnostics.Debug.WriteLine(t));

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var resourceId = "WebViewDemo.Resource.Chart.html";
			var assembly = typeof(WebViewDemoPage).GetTypeInfo().Assembly;
			var html = string.Empty;
			using(Stream stream = assembly.GetManifestResourceStream(resourceId))
			using (var reader = new System.IO.StreamReader(stream)) {
			    html = reader.ReadToEnd ();
				Debug.WriteLine("html:{0}", html);
			}

			var baseUrl = DependencyService.Get<IBaseUrl>().Get();
			webview.LoadContent(html, baseUrl);
		}
	}
}
