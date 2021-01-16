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

      ImageButton clockImageButton = new ImageButton
      {
        Source = "timeClock.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      clockImageButton.Clicked += OnClockImageButtonClicked;

      ImageButton phoneImageBtn = new ImageButton
      {
        Source = "phoneDir.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      phoneImageBtn.Clicked += OnPhoneImageButtonClicked;

      ImageButton jobImageBtn = new ImageButton
      {
        Source = "wrench.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      jobImageBtn.Clicked += OnJobImageButtonClicked;

      string footerText = "© " + DateTime.Now.Year.ToString() + " Techno Herder";

      Content = new StackLayout
      {
        Children = {
          clockImageButton,
          phoneImageBtn,
          jobImageBtn,
          new Label { Text = footerText, TextColor = Color.FromHex("#97bdfc"), Padding = new Thickness( 25, 0, 0, 20 ) }
        }
      };
    }

    void OnPhoneImageButtonClicked(object sender, EventArgs e)
    {

      try
      {
        
        Location msLocation = new Location(47.645160, -122.1306032);

        MapLaunchOptions options = new MapLaunchOptions { Name = "Microsoft Building 25", NavigationMode = NavigationMode.Driving };
        Map.OpenAsync(msLocation, options);
      }
      catch (FeatureNotSupportedException fnsEx)
      {
        // Handle not supported on device exception
      }
      catch (FeatureNotEnabledException fneEx)
      {
        // Handle not enabled on device exception
      }
      catch (PermissionException pEx)
      {
        // Handle permission exception
      }
      catch (Exception ex)
      {
        // Unable to get location
      }


      
    }

    void OnClockImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new TimeClockListPageCS());
    }

    void OnJobImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new TimeClockListPageCS());
    }
  }

}
