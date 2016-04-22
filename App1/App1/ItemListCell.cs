using Xamarin.Forms;

namespace App1
{
    internal class ItemListCell : ViewCell
    {
        public ItemListCell()
        {
            var nameLabel = new Label
            {
                FontFamily = "HelveticaNeue-Medium",
                FontSize = 30,
                TextColor = Color.Red,
                WidthRequest = 500,
                HeightRequest = 40,
                MinimumWidthRequest = 500,
                MinimumHeightRequest = 40, BackgroundColor = Color.Black
            };
            nameLabel.SetBinding(Label.TextProperty, "Name");

            var cellLayout = new StackLayout
            {
                Spacing = 0,
                Padding = new Thickness(10, 5, 10, 5),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { nameLabel }
            };

            View = cellLayout;
        }
    }
}