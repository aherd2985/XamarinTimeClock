using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace TimeClock.Views
{
  public class LandingPageCS : ContentPage
  {
    public LandingPageCS()
    {
      Title = "Home";
      this.BackgroundColor = Color.FromHex("#161616");

      ImageButton codeButton = new ImageButton
      {
        Source = "code.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      codeButton.Clicked += OnCodeImageButtonClicked;

      ImageButton imageScanBtn = new ImageButton
      {
        Source = "ScanBtn.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightBlue
      };
      imageScanBtn.Clicked += OnInvImgBtnClicked;

      string footerText = "© " + DateTime.Now.Year.ToString() + " Techno Herder";

      Content = new StackLayout
      {
        Children = {
          codeButton,
          imageScanBtn,
          new Label { Text = footerText, TextColor = Color.FromHex("#97bdfc"), Padding = new Thickness( 25, 0, 0, 20 ) }
        }
      };
    }
    void OnInvImgBtnClicked(object sender, EventArgs e)
    {
      Location location = new Location(47.645160, -122.1306032);
      MapLaunchOptions options = new MapLaunchOptions { Name = "Microsoft Building 25", NavigationMode = NavigationMode.Driving };

      try
      {
        Map.OpenAsync(location, options);
      }
      catch (Exception ex)
      {
        // No map application available to open
      }
    }
    void OnCodeImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new TimeClockListPageCS());
    }
  }

}
