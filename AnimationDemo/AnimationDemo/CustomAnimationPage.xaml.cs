using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class CustomAnimationPage : ContentPage
	{
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			this.AbortAnimation("RotateTextAnimation");
			lblMessage.CancelAnimation();
		}

		public CustomAnimationPage()
		{
			InitializeComponent();
		}

		Animation parentAnimation;
		protected override void OnAppearing()
		{
			base.OnAppearing();

			parentAnimation = new Animation();
			var scaleUpAnimation = new Animation(
				v => lblMessage.Scale = v,
				1,
				2,
				Easing.SinIn);
			var rotateAnimation = new Animation(
				v => lblMessage.Rotation = v,
				0,
				360);
			var scaleDownAnimation = new Animation(
				v => lblMessage.Scale = v,
				2,
				1,
				Easing.SpringOut);

			parentAnimation.Add(0, 0.5, scaleUpAnimation);
			parentAnimation.Add(0, 1, rotateAnimation);
			parentAnimation.Add(0.5, 1, scaleDownAnimation);
			parentAnimation.Commit(
				this,
				"RotateTextAnimation",
				16,
				5000
			);


			lblMessage.ColorTo(
				Color.Black, 
				Color.Red, 
				(color) => lblMessage.TextColor = color,
				5000
			);
		}
	}
}
