using System;
using System.Reflection;
using ListViewDemo.Controls;
using ListViewDemo.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ListView), typeof(ListViewExRenderer))]
namespace ListViewDemo.Droid.Renderer
{
	public class ListViewExRenderer : ListViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				typeof(Color).GetProperty(
					"Accent", 
					BindingFlags.Public | BindingFlags.Static
				).SetValue(null, Color.Transparent);
			}
		}
	}
}
