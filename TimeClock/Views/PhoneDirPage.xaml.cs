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
        new EmployeeItem() { FirstName = "Emily", LastName = "Sampson", Title = "Bounty Hunter", MarketNm = "West", PhoneNbr = "555-555-5555", Email = "test@gmail.com" },
        new EmployeeItem() { FirstName = "Rex", LastName = "Shin", Title = "Runner", MarketNm = "Interloper", PhoneNbr = "555-123-4567", Email = "nobody@gmail.com" },
        new EmployeeItem() { FirstName = "Zach", LastName = "Smith", Title = "Guard", MarketNm = "Security", PhoneNbr = "555-645-7809", Email = "fake@school.edu" }
    };
      sList.Heading = "S";

      var dList = new PersonList()
    {
        new EmployeeItem() { FirstName = "Jane", LastName = "Doe", Title = "Crusader", MarketNm = "Operations", PhoneNbr = "555-000-9999", Email = "own@usa.gov" }
    };
      dList.Heading = "D";

      var jList = new PersonList()
    {
        new EmployeeItem() { FirstName = "Shoeless", LastName = "Jackson", Title = "Public Relations", MarketNm = "Marketing", PhoneNbr = "555-111-9876", Email = "poop@microsoft.com" }
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

    async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
      if (e.SelectedItem != null)
      {
        await Navigation.PushAsync(new EmployeeContactPage
        {
          BindingContext = e.SelectedItem as EmployeeItem
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
