using System;
using Xamarin.Forms;

namespace DataBinding
{
	public class MyObject : BindableObject
	{
		public MyObject()
		{
			Device.StartTimer(TimeSpan.FromSeconds(1), () => {
				CurrentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
				return true;
			});
		}

		public static readonly BindableProperty MyValueProperty =
			BindableProperty.Create(
				"MyValue",
				typeof(string),
				typeof(MyObject),
				"ABC");
		
		public string MyValue
		{
			get { return (string)GetValue(MyValueProperty); }
			set { SetValue(MyValueProperty, value); }
		}

		public static readonly BindableProperty CurrentTimeProperty =
			BindableProperty.Create(
				"CurrentTime",
				typeof(string),
				typeof(MyObject),
				 null);

		public string CurrentTime
		{
			get { return (string)GetValue(CurrentTimeProperty); }
			private set { SetValue(CurrentTimeProperty, value); }
		}
	}
}
