using System;
using Android.Graphics;
using Android.Util;
using SlideUnlockDemo.Controls;
using SlideUnlockDemo.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CornerRaidusContentView), typeof(CornerRaidusContentViewRenderer))]
namespace SlideUnlockDemo.Droid.Renderers
{
	public class CornerRaidusContentViewRenderer : ViewRenderer
	{
		private float _cornerRadius;
		private RectF _bounds = new RectF();
		private Path _path = new Path();

		protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				var cornerRaidusContentView = e.NewElement as CornerRaidusContentView;

				_cornerRadius = TypedValue.ApplyDimension(
										ComplexUnitType.Dip,
										(float)cornerRaidusContentView.CornerRaidus,
										Context.Resources.DisplayMetrics);
			}
			
			if (e.OldElement != null)
			{
			}

			if (Control != null)
			{
			}
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);

			//用自己的寬高定義畫圖的路徑path
			_bounds = new RectF(0, 0, w, h);
			_path = new Path();
			_path.Reset();
			_path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
			_path.Close();
		}

		public override void Draw(Canvas canvas)
		{
			canvas.Save();
			canvas.ClipPath(_path);
			base.Draw(canvas);  //畫出路徑
			canvas.Restore();
		}
	}
}
