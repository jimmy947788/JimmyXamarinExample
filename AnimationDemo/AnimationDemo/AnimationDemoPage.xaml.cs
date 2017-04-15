using System;
using Xamarin.Forms;

namespace AnimationDemo
{
	public partial class AnimationDemoPage : ContentPage
	{
		public AnimationDemoPage()
		{
			InitializeComponent();
		}

		void Translate_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new TranslateDemoPage());
		}

		void Scale_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new ScaleDemoPage());
		}

		void Rotate_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new RotateDemoPage());
		}

		void Flip_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new FlipDemoPage());
		}

		void Fade_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new FadeDemoPage());
		}

		void Transition_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new TransformersTransitionDemoPage());
		}

		void Layout_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LayoutDemoPage());
		}

		void CustomAnimation_Click(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CustomAnimationPage());

		}
	}
}
