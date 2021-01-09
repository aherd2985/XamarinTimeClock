using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace TimeClock.Views
{
  public class LandingPageCS : ContentPage
  {
    public LandingPageCS()
    {
      Title = "Home";
      this.BackgroundColor = Color.FromHex("#161616");

      ImageButton codeButton = new ImageButton
      {
        Source = "code.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand
      };
      codeButton.Clicked += OnCodeImageButtonClicked;

      ImageButton imageScanBtn = new ImageButton
      {
        Source = "ScanBtn.png",
        HorizontalOptions = LayoutOptions.Center,
        VerticalOptions = LayoutOptions.CenterAndExpand,
        BackgroundColor = Color.LightBlue
      };
      imageScanBtn.Clicked += OnInvImgBtnClicked;

      string footerText = "© " + DateTime.Now.Year.ToString() + " Techno Herder";

      Content = new StackLayout
      {
        Children = {
          codeButton,
          imageScanBtn,
          new Label { Text = footerText, TextColor = Color.FromHex("#97bdfc"), Padding = new Thickness( 25, 0, 0, 20 ) }
        }
      };
    }
    void OnInvImgBtnClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new TimeClockItemPageCS
      {
        BindingContext = new TimeClockItem()
      });
    }
    void OnCodeImageButtonClicked(object sender, EventArgs e)
    {
      Navigation.PushAsync(new TimeClockListPageCS());
    }
  }

}
