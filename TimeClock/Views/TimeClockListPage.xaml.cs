using System;
using Xamarin.Forms;

namespace TimeClock
{
    public partial class TimeClockListPage : ContentPage
    {
        public TimeClockListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimeClockItemPage
            {
                BindingContext = new TimeClockItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TimeClockItemPage
                {
                    BindingContext = e.SelectedItem as TimeClockItem
                });
            }
        }
    }
}
