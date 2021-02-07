using TimeClock.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

[assembly: ExportFont("FontAwesome6Solid.otf", Alias = "FontAwesomeSolid")]

namespace TimeClock
{
  public partial class App : Application
  {
    static TimeClockItemDatabase database;


    public App()
    {
      InitializeComponent();

      NavigationPage nav = new NavigationPage(new LoginPage());
      nav.BarBackgroundColor = (Color)App.Current.Resources["darkBlue"];
      nav.BarTextColor = Color.White;

      MainPage = nav;

      Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    public static TimeClockItemDatabase Database
    {
      get
      {
        if (database == null)
        {
          database = new TimeClockItemDatabase();
        }
        return database;
      }
    }

    protected override void OnStart()
    {

    }

    protected override void OnSleep()
    {

    }

    protected override void OnResume()
    {

    }

    protected void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
      var access = e.NetworkAccess;
      var profiles = e.ConnectionProfiles;
    }
  }
}

