using System.Collections.Generic;
using TimeClock.Models;
using Xamarin.Forms;
namespace TimeClock.Views
{
  public class PhoneDirPageCS : ContentPage
  {
    ListView listView;

    public PhoneDirPageCS()
    {
      Title = "Phone Directory";
      BackgroundColor = Color.Black;

      listView = new ListView
      {
        BackgroundColor = Color.Black,
        Margin = new Thickness(20),
        ItemTemplate = new DataTemplate(() =>
        {
          Label label = new Label
          {
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            TextColor = Color.White
          };
          label.SetBinding(Label.TextProperty, "FirstName");

          Label lastNameLbl = new Label
          {
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            TextColor = Color.White
          };
          lastNameLbl.SetBinding(Label.TextProperty, "LastName");

          StackLayout stackLayout = new StackLayout
          {
            Margin = new Thickness(20, 0, 0, 0),
            Orientation = StackOrientation.Horizontal,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Children = { label, lastNameLbl }
          };

          return new ViewCell { View = stackLayout };
        })
      };
      listView.ItemSelected += async (sender, e) =>
      {

        if (e.SelectedItem != null)
        {
          await Navigation.PushAsync(new TimeClockItemPageCS
          {
            //BindingContext = e.SelectedItem as TimeClockItem
          });
        }
      };

      Content = listView;
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();

      //listView.ItemsSource = await App.Database.GetItemsAsync();
      listView.ItemsSource = getEmployees();
    }

    public List<EmployeeItem> getEmployees()
    {

      List<EmployeeItem> employess = new List<EmployeeItem>();
      EmployeeItem emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Andrew",
        LastName = "Tesat"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Bob",
        LastName = "Tesawdt"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Bruce",
        LastName = "Teefwwt"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Conan",
        LastName = "Twget"
      };
      employess.Add(emp);
      emp = new EmployeeItem
      {
        Email = "test@gmail.com",
        FirstName = "Kal",
        LastName = "Rkjbt"
      };
      employess.Add(emp);



      return employess;
    }
  }
}
