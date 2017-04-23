using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SlideUnlockDemo.Controls
{
	public partial class SlideToUnlock : ContentView
	{
		public SlideToUnlock()
		{
			InitializeComponent();
		}
		
		protected override void OnParentSet()
		{
			base.OnParentSet();
			lblDisplayText.Text = SlideText;
		}
		
		public string SlideText { get; set; }
		public string UnlockText { get; set; }
		
		public event EventHandler Unlock;
		async protected void CustomSlider_Unlock(object sender, System.EventArgs e)
		{
			lblDisplayText.Text = UnlockText;
			lblDisplayText.TextColor = Color.White;
			if (Unlock != null)
			{
				Unlock(this, EventArgs.Empty);
			}
			await cvChangeBackground.LayoutTo(cvBackground.Bounds, 100);
		}

		//滑動變更進度
		async protected void CustomSlider_Changing(object sender, CustomSliderValueChangingEventArgs e)
		{
			var bounds = new Rectangle(0, 0, e.X, 52);
			await cvChangeBackground.LayoutTo(bounds, 1);
		}

		//放手彈回去原點
		async protected void CustomSlider_TouchUp(object sender, System.EventArgs e)
		{
			var bounds = new Rectangle(0, 0, 0, 52);
			await cvChangeBackground.LayoutTo(bounds, 1);
		}
	}
}
