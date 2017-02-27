using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AbsoluteLayoutDemo
{
	public partial class Example1Page : ContentPage
	{
		int sleepSeconds = 0;
		int waitSecond = 5;
		public Example1Page()
		{
			InitializeComponent();

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				sleepSeconds++;
				if (sleepSeconds >= waitSecond)
				{
					bvOverlayer.IsVisible = false;
					activityIndicator.IsRunning = false;
				}
				return sleepSeconds < waitSecond;
			});
		}
	}
}
