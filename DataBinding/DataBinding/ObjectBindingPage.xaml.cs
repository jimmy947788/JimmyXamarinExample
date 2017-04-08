using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace DataBinding
{
	public partial class ObjectBindingPage : ContentPage
	{
		public ObjectBindingPage()
		{
			InitializeComponent();

			Slider1.BindingContext = myObject;
			Slider1.SetBinding(Slider.ValueProperty, "MyValue");

			Device.StartTimer(TimeSpan.FromSeconds(1), () => {
				Debug.WriteLine("myObject.MyValue={0}", myObject.MyValue);
				return true;
			});
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			myObject.MyValue = "0.8";
		}
	}
}
