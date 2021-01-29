using TimeClock.Views;
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
    }
}

