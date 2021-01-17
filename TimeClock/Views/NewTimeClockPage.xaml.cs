using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class NewTimeClockPage : ContentPage
  {
    public NewTimeClockPage()
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
