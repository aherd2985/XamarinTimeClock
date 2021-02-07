using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeClock.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class SearchPage : ContentPage
  {
    public SearchPage()
    {
      //FirstLoad();
      //var herp = App.JobDatabase.GetItemsAsync().Result;   //SearchItemAsync("123").Result;

      //herp = App.JobDatabase.SearchItemAsync("123").Result;

      //var poop = "poop";
      InitializeComponent();

    }
    void OnTextChanged(object sender, EventArgs e)
    {
      SearchBar searchBar = (SearchBar)sender;
      searchResults.ItemsSource = App.JobDatabase.SearchItemAsync(searchBar.Text).Result;
    }

    void FirstLoad()
    {
      App.JobDatabase.CreateDummyData();
    }
  }
}