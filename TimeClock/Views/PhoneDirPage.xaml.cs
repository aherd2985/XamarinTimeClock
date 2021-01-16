using System;
using System.Collections.Generic;
using TimeClock.Models;
using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class PhoneDirPage : ContentPage
  {
    public PhoneDirPage()
    {
      InitializeComponent();
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();


      listView.ItemsSource = getEmployees();
      //listView.ItemsSource = await App.Database.GetItemsAsync();
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





    public List<EmployeeItem> getEmployees()
    {

      List<EmployeeItem> employess = new List<EmployeeItem>();
      EmployeeItem emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Andrew",
        LastName = "Tesat",
        Title = "Master Ninja",
        MarketNm = "Corporate"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Bob",
        LastName = "Tesawdt",
        Title = "Bounty Hunter",
        MarketNm = "Human Resources"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Bruce",
        LastName = "Teefwwt",
        Title = "Security Guru",
        MarketNm = "Corporate"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Conan",
        LastName = "Twget",
        Title = "Slave Driver",
        MarketNm = "Operations"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Kal",
        LastName = "Rkjbt",
        Title = "Do-Gooder",
        MarketNm = "Safety"
      };
      employess.Add(emp);



      return employess;
    }
  }
}
