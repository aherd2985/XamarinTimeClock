using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TimeClock
{
  public class TimeClockItemPageCS : ContentPage
  {
    public TimeClockItemPageCS()
    {
      Title = "TimeClock Item";
      BackgroundColor = Color.Black;

      Entry notesEntry = new Entry();
      notesEntry.SetBinding(Entry.TextProperty, "Notes");

      Button saveButton = new Button { Text = "Save" };
      saveButton.Clicked += async (sender, e) =>
      {
        TimeClockItem timeClock = (TimeClockItem)BindingContext;
        if (timeClock.TimePunch.Year == 1)
        {
          timeClock.TimePunch = DateTime.Now;

          TimeClockItem lastItem = App.Database.GetLastTimeClockItemAsync().Result;
          if (lastItem != null)
            timeClock.IsClockIn = lastItem.IsClockIn == false;
          else
            timeClock.IsClockIn = true;

          Location location = await Geolocation.GetLastKnownLocationAsync();
          timeClock.IsMock = false;

          if (location != null)
          {
            timeClock.gpsDetail = location.Accuracy.ToString();
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
        }

        await App.Database.SaveItemAsync(timeClock);
        await Navigation.PopAsync();
      };

      var cancelButton = new Button { Text = "Cancel" };
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
                    new Label { Text = "Notes" },
                    notesEntry,
                    saveButton,
                    cancelButton
                }
      };
    }
  }
}
