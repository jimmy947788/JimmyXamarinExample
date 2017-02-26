using Xamarin.Forms;

namespace GridDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();


			var grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Star)
			});
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1, GridUnitType.Star)
			});
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1, GridUnitType.Star)
			});
			var topLeft = new Label
			{
				Text = "Top Left",
				BackgroundColor = Color.Red
			};
			var topRight = new Label
			{
				Text = "Top Right",
				BackgroundColor = Color.Green
			};
			var bottomLeft = new Label
			{
				Text = "Bottom Left",
				BackgroundColor = Color.Blue
			};
			var bottomRight = new Label
			{
				Text = "Bottom Right",
				BackgroundColor = Color.Yellow
			};
			grid.Children.Add(topLeft, 0, 0);
			grid.Children.Add(topRight, 0, 1);
			grid.Children.Add(bottomLeft, 1, 0);
			grid.Children.Add(bottomRight, 1, 1);

			Content = grid;
		}
	}
}
