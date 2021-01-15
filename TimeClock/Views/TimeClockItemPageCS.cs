using System;
using Xamarin.Forms;

namespace TimeClock
{
    public class TimeClockItemPageCS : ContentPage
    {
        public TimeClockItemPageCS()
        {
            Title = "TimeClock Item";

            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Notes");

            var doneSwitch = new Switch();
            doneSwitch.SetBinding(Switch.IsToggledProperty, "Done");

            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += async (sender, e) =>
            {
                var timeClock = (TimeClockItem)BindingContext;
                timeClock.TimePunch = DateTime.Now;
                await App.Database.SaveItemAsync(timeClock);
                await Navigation.PopAsync();
            };

            var deleteButton = new Button { Text = "Delete" };
            deleteButton.Clicked += async (sender, e) =>
            {
                var timeClock = (TimeClockItem)BindingContext;
                await App.Database.DeleteItemAsync(timeClock);
                await Navigation.PopAsync();
            };

            var cancelButton = new Button { Text = "Cancel" };
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
                    new Label { Text = "Notes" },
                    notesEntry,
                    new Label { Text = "Done" },
                    doneSwitch,
                    saveButton,
                    deleteButton,
                    cancelButton
                }
            };
        }
    }
}
