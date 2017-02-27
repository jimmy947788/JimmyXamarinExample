using Xamarin.Forms;

namespace RelativeLayoutDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			var layout = new RelativeLayout();
			var redBox = new BoxView
			{
				Color = Color.Red,
			};
			layout.Children.Add(redBox,
								Constraint.RelativeToParent((parent) =>
								{
									return parent.X;
								}),
								Constraint.RelativeToParent((parent) =>
								{
									return parent.Y * .15;
								}),
								Constraint.RelativeToParent((parent) =>
								{
									return parent.Width;
								}),
								Constraint.RelativeToParent((parent) =>
								{
									return parent.Height * .8;
								}));

			var blueBox = new BoxView
			{
				Color = Color.Blue,
			};
			layout.Children.Add(blueBox,
								Constraint.RelativeToView(redBox, (parent, relativeView) =>
								{
									return relativeView.X + 20;
								}),
								Constraint.RelativeToView(redBox, (parent, relativeView) =>
								{
									return relativeView.Y + 20;
								}),
								Constraint.RelativeToParent((parent) =>
								{
									return parent.Width * .5;
								}),
								Constraint.RelativeToParent((parent) =>
								{
									return parent.Height * .5;
								}));

			Content = layout;
		}
	}
}
