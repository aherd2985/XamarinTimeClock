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

      //TimeClockItem codeItem = (TimeClockItem)BindingContext;

      Entry notesEntry = new Entry();
      notesEntry.SetBinding(Entry.TextProperty, "Notes");
      notesEntry.BackgroundColor = Color.FromHex("#292929");
      notesEntry.TextColor = Color.FromHex("#32cd32");

      Binding newPb = new Binding("TimePunch");
      newPb.StringFormat = "Punch Timestamp: {0:MMM d, yyyy hh:mm tt}";
      Label tpLbl = new Label();
      tpLbl.SetBinding(Label.TextProperty, newPb);
      tpLbl.TextColor = Color.FromHex("#CCFFFF");
      tpLbl.Margin = new Thickness(0, 30, 0, 0);

      newPb = new Binding("gpsLatitude");
      newPb.StringFormat = "GPS Latitude: {0}";
      Label latLbl = new Label();
      latLbl.SetBinding(Label.TextProperty, newPb);
      latLbl.TextColor = Color.FromHex("#CCFFFF");

      newPb = new Binding("gpsLongitude");
      newPb.StringFormat = "GPS Longitude: {0}";
      Label lonLbl = new Label();
      lonLbl.SetBinding(Label.TextProperty, newPb);
      lonLbl.TextColor = Color.FromHex("#CCFFFF");

      newPb = new Binding("gpsLastTimestamp");
      newPb.StringFormat = "GPS Last TS: {0:MMM d, yyyy hh:mm tt}";
      Label gpsLastLbl = new Label();
      gpsLastLbl.SetBinding(Label.TextProperty, newPb);
      gpsLastLbl.TextColor = Color.FromHex("#CCFFFF");

      newPb = new Binding("gpsDetail");
      newPb.StringFormat = "GPS Detail Level: {0}";
      Label gpsDetailLbl = new Label();
      gpsDetailLbl.SetBinding(Label.TextProperty, newPb);
      gpsDetailLbl.TextColor = Color.FromHex("#CCFFFF");

      newPb = new Binding("IsMock");
      newPb.StringFormat = "GPS Data was Mocked: {0}";
      Label mockLbl = new Label();
      mockLbl.SetBinding(Label.TextProperty, newPb);
      mockLbl.TextColor = Color.FromHex("#CCFFFF");

      Button saveButton = new Button { Text = "Save", Margin = new Thickness(0, 50, 0, 0), BackgroundColor = Color.FromHex("#00FFFF"), TextColor = Color.FromHex("#000033") };
      saveButton.Clicked += async (sender, e) =>
      {
        TimeClockItem timeClock = (TimeClockItem)BindingContext;
        await App.Database.SaveItemAsync(timeClock);
        await Navigation.PopAsync();
      };

      Button cancelButton = new Button { Text = "Cancel", BackgroundColor = Color.FromHex("#FF0000"), TextColor = Color.White, Margin = new Thickness(0, 20, 0, 0) };
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
                    tpLbl,
                    latLbl,
                    lonLbl,
                    gpsLastLbl,
                    gpsDetailLbl,
                    mockLbl,
                    saveButton,
                    cancelButton
                }
      };
    }
  }
}
