using System;
using System.Collections.Generic;
using TimeClock.Models;
using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class PhoneDirPage : ContentPage
  {
    private List<PersonList> _listOfPeople;
    public List<PersonList> ListOfPeople
    {
      get { return _listOfPeople; }

      set { _listOfPeople = value; base.OnPropertyChanged(); }
    }

    public PhoneDirPage()
    {
      InitializeComponent();
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();


      //listView.ItemsSource = getEmployees();

      var sList = new PersonList()
    {
        new EmployeeItem() { FirstName = "Sally", LastName = "Sampson" },
        new EmployeeItem() { FirstName = "Taylor", LastName = "Swift" },
        new EmployeeItem() { FirstName = "John", LastName = "Smith" }
    };
      sList.Heading = "S";

      var dList = new PersonList()
    {
        new EmployeeItem() { FirstName = "Jane", LastName = "Doe" }
    };
      dList.Heading = "D";

      var jList = new PersonList()
    {
        new EmployeeItem() { FirstName = "Billy", LastName = "Joel" }
    };
      jList.Heading = "J";

      var list = new List<PersonList>()
    {

        dList,
        jList,
        sList
    };

      //ListOfPeople = list;
      listView.ItemsSource = list;
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
