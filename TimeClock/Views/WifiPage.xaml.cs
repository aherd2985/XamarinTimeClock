using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeClock.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class WifiPage : ContentPage
  {
    public WifiPage()
    {
      InitializeComponent();

      var current = Connectivity.NetworkAccess;

      if (current == NetworkAccess.Internet)
      {
        // Connection to internet is available
        internetLbl.IsVisible = true;
      }
      else
      {
        internetLbl.IsVisible = false;
      }

      var profiles = Connectivity.ConnectionProfiles;
      if (profiles.Contains(ConnectionProfile.Ethernet))
      {
        // Active Ethernet connection.
        ethLbl.IsVisible = true;
      }
      else if (profiles.Contains(ConnectionProfile.WiFi))
      {
        // Active Wi-Fi connection.
        wifiLbl.IsVisible = true;
      }
      else if (profiles.Contains(ConnectionProfile.Cellular))
      {
        // Active Cellular connection.
        cellLbl.IsVisible = true;
      }
      else if (profiles.Contains(ConnectionProfile.Bluetooth))
      {
        // Active Bluetooth connection.
        blueLbl.IsVisible = true;
      }
      else if (profiles.Contains(ConnectionProfile.Unknown))
      {
        // Active Unknown connection.
        unkLbl.IsVisible = true;
      }
    }
  }
}