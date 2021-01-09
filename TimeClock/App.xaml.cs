using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TimeClock
{
    public partial class App : Application
    {
        static TimeClockItemDatabase database;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new TimeClockListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
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

