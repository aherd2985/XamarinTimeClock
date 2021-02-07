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
      NavigationPage.SetHasBackButton(this, false);

      ImageButton clockImageButton = new ImageButton
      {
        Source = "timeClock.png",
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Margin = new Thickness(0, 10, 0, 0)
      };
      clockImageButton.Clicked += OnClockImageButtonClicked;

      ImageButton phoneImageBtn = new ImageButton
      {
        Source = "phoneDir.png",
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Margin = new Thickness(0, 20, 0, 0)
      };
      phoneImageBtn.Clicked += OnPhoneImageButtonClicked;

      ImageButton jobImageBtn = new ImageButton
      {
        Source = "wrench.png",
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Margin = new Thickness(0, 20, 0, 0)
      };
      jobImageBtn.Clicked += OnJobImageButtonClicked;

      ImageButton syncImageBtn = new ImageButton
      {
        Source = "sync.png",
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Margin = new Thickness(0, 20, 0, 0)
      };
      syncImageBtn.Clicked += OnSyncImageButtonClicked;

      ImageButton wifiImageBtn = new ImageButton
      {
        Source = "wifi.png",
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Margin = new Thickness(0, 20, 0, 0)
      };
      wifiImageBtn.Clicked += OnWifiImageButtonClicked;

      ImageButton searchImageBtn = new ImageButton
      {
        Source = "job.png",
        HorizontalOptions = LayoutOptions.CenterAndExpand,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        Margin = new Thickness(0, 20, 0, 0)
      };
      searchImageBtn.Clicked += OnSearchImageButtonClicked;

      string footerText = "© " + DateTime.Now.Year.ToString() + " Techno Herder";

      Content = new StackLayout
      {
        Children = {
          new StackLayout
        { 
        Children = {
          clockImageButton,
          phoneImageBtn,
          },
        Orientation = StackOrientation.Horizontal
        },
          new StackLayout
          { 
        Children = {
          jobImageBtn,
          syncImageBtn,
            },
        Orientation = StackOrientation.Horizontal
          },
          new StackLayout
          {
        Children = {
          wifiImageBtn,
          searchImageBtn,
            },
        Orientation = StackOrientation.Horizontal
          },
          new Label { Text = footerText, TextColor = Color.FromHex("#97bdfc"), VerticalTextAlignment = TextAlignment.End
                      , Padding = new Thickness( 25, 10, 0, 20 ), VerticalOptions = LayoutOptions.EndAndExpand
                    }
        },
        VerticalOptions = LayoutOptions.FillAndExpand
      };
    }

    void OnPhoneImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new PhoneDirPage());
    }

    void OnClockImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new TimeClockListPageCS());
    }

    void OnSyncImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new SyncDataPage());
    }
    void OnWifiImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new WifiPage());
    }
    void OnSearchImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new SearchPage());
    }

    void OnJobImageButtonClicked(object sender, EventArgs e)
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
        DisplayAlert("Error", fnsEx.InnerException.ToString(), "OK");
      }
      catch (FeatureNotEnabledException fneEx)
      {
        // Handle not enabled on device exception
        DisplayAlert("Error", fneEx.InnerException.ToString(), "OK");
      }
      catch (PermissionException pEx)
      {
        // Handle permission exception
        DisplayAlert("Error", pEx.InnerException.ToString(), "OK");
      }
      catch (Exception ex)
      {
        // Unable to get location
        DisplayAlert("Error", ex.InnerException.ToString(), "OK");
      }
    }
  }

}
