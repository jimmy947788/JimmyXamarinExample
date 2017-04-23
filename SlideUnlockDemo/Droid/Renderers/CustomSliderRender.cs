using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using SlideUnlockDemo.Controls;
using SlideUnlockDemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderRender))]
namespace SlideUnlockDemo.Droid.Renderers
{
	public class CustomSliderRender : SliderRenderer, SeekBar.IOnSeekBarChangeListener
	{
		static readonly float THUMB_WIDTH = 52;
		static readonly float THUMB_HEIGHT = 52;
		static readonly int MAXVALUE = 100;
		static readonly int MINVALUE = 0;
		CustomSlider customSlider;
		protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				customSlider = e.NewElement as CustomSlider;
			}
			
			if (e.OldElement != null)
			{
			}
			
			if (Control != null)
			{
				var thumbBitmap = BitmapFactory.DecodeResource(Context.Resources, Resource.Drawable.thumb);
				var thumbWidthPx = Convert.ToInt32(ConvertDpToPixels(THUMB_WIDTH));
				var thumbHeightPx = Convert.ToInt32(ConvertDpToPixels(THUMB_HEIGHT));
				var newBmp = Bitmap.CreateScaledBitmap(thumbBitmap, thumbWidthPx, thumbHeightPx, true);
				var newThumbBitmap = new BitmapDrawable(Context.Resources, newBmp);

				Control.SetThumb(newThumbBitmap);
				Control.ThumbOffset = (Control.ThumbOffset / 2) + 8;
				Control.ProgressDrawable = new ColorDrawable(Android.Graphics.Color.Transparent);

				Control.Max = MAXVALUE;
				Control.SetOnSeekBarChangeListener(this); 
			}
		}

		private float ConvertDpToPixels(float dpValue)
		{
			var pixel = dpValue * Resources.DisplayMetrics.Density;
			return pixel;
		}
		
		private int ConvertPixelsToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
			return dp;
		}
		
		public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
		{
			System.Console.WriteLine("OnProgressChanged={0}", progress);

			Rect thumbRect = seekBar.Thumb.Bounds;
			var centerThumbX = ConvertPixelsToDp(thumbRect.CenterX());
			var centerThumbY = ConvertPixelsToDp(thumbRect.CenterY());
			Console.WriteLine("thumb center X:{0} Y:{1}", centerThumbX, centerThumbY);
			customSlider.OnValueChanging(centerThumbX, centerThumbY);
			if ( progress == Control.Max)
			{
				customSlider.OnUnlock();
			}
		}

		public void OnStartTrackingTouch(SeekBar seekBar)
		{
			Console.WriteLine("OnStartTrackingTouch");
		}

		public void OnStopTrackingTouch(SeekBar seekBar)
		{
			Console.WriteLine("OnStopTrackingTouch");
			if (seekBar.Progress < 100)
			{
				seekBar.Progress = 0;
				customSlider.OnTouchUp();
			}
		}
	}
}
