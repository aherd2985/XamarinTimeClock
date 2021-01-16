﻿using Xamarin.Forms;

namespace TimeClock
{
  public class TimeClockListPageCS : ContentPage
  {
    ListView listView;

    public TimeClockListPageCS()
    {
      Title = "TimeClock";
      BackgroundColor = Color.Black;

      var toolbarItem = new ToolbarItem
      {
        Text = "+",
        IconImageSource = Device.RuntimePlatform == Device.iOS ? null : "plus.png"
      };
      toolbarItem.Clicked += async (sender, e) =>
      {
        await Navigation.PushAsync(new TimeClockItemPageCS
        {
          BindingContext = new TimeClockItem()
        });
      };
      ToolbarItems.Add(toolbarItem);

      listView = new ListView
      {
        Margin = new Thickness(20),
        ItemTemplate = new DataTemplate(() =>
        {
          var label = new Label
          {
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalOptions = LayoutOptions.StartAndExpand
          };
          label.SetBinding(Label.TextProperty, "TimePunch");

          var tick = new Image
          {
            Source = ImageSource.FromFile("check.png"),
            HorizontalOptions = LayoutOptions.End
          };
          tick.SetBinding(VisualElement.IsVisibleProperty, "IsMock");

          var stackLayout = new StackLayout
          {
            Margin = new Thickness(20, 0, 0, 0),
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children = { label, tick }
          };

          return new ViewCell { View = stackLayout };
        })
      };
      listView.ItemSelected += async (sender, e) =>
      {

        if (e.SelectedItem != null)
        {
          await Navigation.PushAsync(new TimeClockItemPageCS
          {
            BindingContext = e.SelectedItem as TimeClockItem
          });
        }
      };

      Content = listView;
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();

      listView.ItemsSource = await App.Database.GetItemsAsync();
    }
  }
}
