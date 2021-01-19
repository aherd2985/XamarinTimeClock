using System;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace TimeClock.Views
{
  public class NewTimeClockPageCS : ContentPage
  {
    public NewTimeClockPageCS()
    {
      Title = "TimeClock Item";
      BackgroundColor = Color.Black;

      //TimeClockItem codeItem = (TimeClockItem)BindingContext;

      Editor notesEntry = new Editor();
      notesEntry.SetBinding(Editor.TextProperty, "Notes");
      notesEntry.BackgroundColor = Color.FromHex("#292929");
      notesEntry.TextColor = Color.FromHex("#32cd32");
      notesEntry.HeightRequest = 300;

      Button saveButton = new Button { Text = "Create", Margin = new Thickness(0, 50, 0, 0), BackgroundColor = Color.FromHex("#00FFFF"), TextColor = Color.FromHex("#000033") };

      saveButton.Clicked += async (sender, e) =>
      {
        TimeClockItem timeClock = (TimeClockItem)BindingContext;

        timeClock.TimePunch = DateTime.Now;

        TimeClockItem lastItem = App.Database.GetLastTimeClockItemAsync().Result;
        if (lastItem != null)
        {
          timeClock.IsClockIn = lastItem.IsClockIn == false;
          timeClock.IsClockOut = lastItem.IsClockIn == true;
        }
        else
        {
          timeClock.IsClockIn = true;
          timeClock.IsClockOut = false;
        }

        Location location = await Geolocation.GetLastKnownLocationAsync();
        timeClock.IsMock = false;

        if (location != null)
        {
          if (location.Accuracy.HasValue)
          {
            double value = location.Accuracy.Value;

            GeolocationAccuracy enumDisplayStatus = (GeolocationAccuracy)value;
            string stringValue = enumDisplayStatus.ToString();

            timeClock.gpsDetail = stringValue;

          }

          timeClock.gpsLatitude = location.Latitude.ToString();
          timeClock.gpsLongitude = location.Longitude.ToString();
          timeClock.gpsLastTimestamp = location.Timestamp;

          if (location.IsFromMockProvider)
          {
            // location is from a mock provider
            timeClock.IsMock = true;
          }
          //Location msLocation = new Location(47.645160, -122.1306032);
          //double miles = Location.CalculateDistance(msLocation, location, DistanceUnits.Miles);
        }

        await App.Database.SaveItemAsync(timeClock);
        await Navigation.PopAsync();
      };

      Button cancelButton = new Button { Text = "Cancel", BackgroundColor = Color.FromHex("#FF0000") , TextColor = Color.White, Margin = new Thickness(0, 20, 0, 0) };
      cancelButton.Clicked += async (sender, e) =>
      {
        await Navigation.PopAsync();
      };

      Content = new StackLayout
      {
        Margin = new Thickness(20),
        VerticalOptions = LayoutOptions.StartAndExpand,
        Children =
                {
                    new Label { Text = "Notes", TextColor = Color.White },
                    notesEntry,
                    saveButton,
                    cancelButton
                }
      };
    }
  }
}
