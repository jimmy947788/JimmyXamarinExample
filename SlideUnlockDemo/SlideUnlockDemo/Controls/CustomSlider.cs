using System;
using Xamarin.Forms;

namespace SlideUnlockDemo.Controls
{
	public class CustomSliderValueChangingEventArgs : EventArgs
	{
		int x, y;
		public CustomSliderValueChangingEventArgs(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public int X { 
			get { return this.x; } 
		}
		public int Y {
			get { return this.y; }
		}
	}
	
	public class CustomSlider : Slider
	{
		public event EventHandler<CustomSliderValueChangingEventArgs> ValueChanging;
		public void OnValueChanging(int x, int y)
		{
			if (ValueChanging != null)
				ValueChanging(this, new CustomSliderValueChangingEventArgs(x, y));
		}

		public event EventHandler Unlock;
		public void OnUnlock()
		{
			if (Unlock != null)
				Unlock(this, EventArgs.Empty);
		}

		public event EventHandler TouchUp;
		public void OnTouchUp()
		{
			if (TouchUp != null)
				TouchUp(this, EventArgs.Empty);
		}
	}
}
