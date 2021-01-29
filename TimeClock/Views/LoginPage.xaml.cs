using System;
using TimeClock.Data;
using Xamarin.Essentials;

using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class LoginPage : ContentPage
  {
    public LoginPage()
    {
      InitializeComponent();


      try
      {
        string secEmpId = SecureStorage.GetAsync("empID").Result;
        string secCompId = SecureStorage.GetAsync("compID").Result;

        // Navigation.PushAsync(new LandingPageCS());
      }
      catch (Exception ex)
      {
        // Possible that device doesn't support secure storage on device.
        DisplayAlert("Error", ex.InnerException.ToString(), "OK");
      }


      //string result = await DisplayPromptAsync("Question 2", "What's 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);

       

     
      

      



    }

    async void loginBtn_Clicked(System.Object sender, System.EventArgs e)
    {
      string uIdResult = await DisplayPromptAsync("User Credentials", "What's your user name?");

      string pwResult = await DisplayPromptAsync("User Credentials", "What's your password?");

      // first example
      //    string authData = string.Format ("{0}:{1}", Constants.Username, Constants.Password);
      //   string authHeaderValue = Convert.ToBase64String (Encoding.UTF8.GetBytes (authData));

      //   HttpClient _client = new HttpClient();
      //   _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue ("Basic", authHeaderValue);


      // 2nd example
      //    Uri uri = new Uri (string.Format (Constants.TodoItemsUrl, string.Empty));

      //  HttpResponseMessage response = await client.GetAsync (uri);
      //  if (response.IsSuccessStatusCode)
      //  {
      //      string content = await response.Content.ReadAsStringAsync ();
      //     Items = JsonConvert.DeserializeObject <List<TodoItem>> (content);
      //  }

      string cryptoCheck = Crypto.Encrypt("poop", "1SuperSecure$$$BorderWall!");

      try
      {
        _ = SecureStorage.SetAsync("empID", "007");
        _ = SecureStorage.SetAsync("compID", "1001");
      }
      catch (Exception ex)
      {
        // Possible that device doesn't support secure storage on device.
        _ = DisplayAlert("Error", ex.Message.ToString(), "OK");
      }

      await Navigation.PushAsync(new LandingPageCS());
    }
  }
}
