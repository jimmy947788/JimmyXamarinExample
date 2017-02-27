using Xamarin.Forms;

namespace AbsoluteLayoutDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			var layout = new AbsoluteLayout();

			var boxview1 = new BoxView
			{
				BackgroundColor = Color.Gray
			};
			AbsoluteLayout.SetLayoutBounds(boxview1,
									   new Rectangle(0, 0, 1, 1));
			AbsoluteLayout.SetLayoutFlags(boxview1,
			                              AbsoluteLayoutFlags.All);
			layout.Children.Add(boxview1);

			var boxview2 = new BoxView
			{
				BackgroundColor = Color.Aqua
			};
			AbsoluteLayout.SetLayoutBounds(boxview2,
									   new Rectangle(.5, 0.1, 100, 100));
			AbsoluteLayout.SetLayoutFlags(boxview2,
										  AbsoluteLayoutFlags.PositionProportional);
			layout.Children.Add(boxview2);

			var boxview3 = new BoxView
			{
				BackgroundColor = Color.Green
			};
			AbsoluteLayout.SetLayoutBounds(boxview3,
									   new Rectangle(0, 1, 1, 60));
			AbsoluteLayout.SetLayoutFlags(boxview3,
										  AbsoluteLayoutFlags.PositionProportional|
			                              AbsoluteLayoutFlags.WidthProportional);
			layout.Children.Add(boxview3);

			Content = layout;
		}
	}
}
