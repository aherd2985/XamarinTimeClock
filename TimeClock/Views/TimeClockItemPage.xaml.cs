using System;
using Xamarin.Forms;

namespace TimeClock
{
    public partial class TimeClockItemPage : ContentPage
    {
        public TimeClockItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var timeClock = (TimeClockItem)BindingContext;
            timeClock.TimePunch = DateTime.Now;
            await App.Database.SaveItemAsync(timeClock);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
