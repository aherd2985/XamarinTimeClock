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
      notesEntry.BackgroundColor = Color.FromHex("#292929");
      notesEntry.TextColor = Color.FromHex("#32cd32");

      Entry timeEntry = new Entry();
      timeEntry.SetBinding(Entry.TextProperty, "TimePunch");
      timeEntry.BackgroundColor = Color.FromHex("#292929");
      timeEntry.TextColor = Color.FromHex("#32cd32");
      timeEntry.IsReadOnly = true;


      var newPb = new Binding("TimePunch");
      //newPb.ElementName = pb.ElementName;
      newPb.StringFormat = "{0:d}";
      //MinText.SetBinding(TextBlock.TextProperty, newPb);

      Label label = new Label();
      label.SetBinding(Label.TextProperty, newPb);
      label.TextColor = Color.Red;

      Entry latEntry = new Entry();
      latEntry.SetBinding(Entry.TextProperty, "gpsLatitude");
      latEntry.BackgroundColor = Color.FromHex("#292929");
      latEntry.TextColor = Color.FromHex("#32cd32");
      latEntry.IsReadOnly = true;

      Entry lonEntry = new Entry();
      lonEntry.SetBinding(Entry.TextProperty, "gpsLongitude");
      lonEntry.BackgroundColor = Color.FromHex("#292929");
      lonEntry.TextColor = Color.FromHex("#32cd32");
      lonEntry.IsReadOnly = true;

      Entry gpsLastEntry = new Entry();
      gpsLastEntry.SetBinding(Entry.TextProperty, "gpsLastTimestamp");
      gpsLastEntry.BackgroundColor = Color.FromHex("#292929");
      gpsLastEntry.TextColor = Color.FromHex("#32cd32");
      gpsLastEntry.IsReadOnly = true;

      Entry gpsDetailEntry = new Entry();
      gpsDetailEntry.SetBinding(Entry.TextProperty, "gpsDetail");
      gpsDetailEntry.BackgroundColor = Color.FromHex("#292929");
      gpsDetailEntry.TextColor = Color.FromHex("#32cd32");
      gpsDetailEntry.IsReadOnly = true;

      Entry mockEntry = new Entry();
      mockEntry.SetBinding(Entry.TextProperty, "IsMock");
      mockEntry.BackgroundColor = Color.FromHex("#292929");
      mockEntry.TextColor = Color.FromHex("#32cd32");
      mockEntry.IsReadOnly = true;

      Button saveButton = new Button { Text = "Save" };
      saveButton.Clicked += async (sender, e) =>
      {
        TimeClockItem timeClock = (TimeClockItem)BindingContext;
        if (timeClock.TimePunch.Year == 1)
        {
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

      Button cancelButton = new Button { Text = "Cancel" };
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
                    timeEntry,
                    label,
                    latEntry,
                    lonEntry,
                    gpsLastEntry,
                    gpsDetailEntry,
                    mockEntry,
                    saveButton,
                    cancelButton
                }
      };
    }
  }
}
