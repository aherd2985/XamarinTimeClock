using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class EmployeeContactPage : ContentPage
  {
    public EmployeeContactPage()
    {
      InitializeComponent();
    }

    void PhoneDialerClicked(System.Object sender, System.EventArgs e)
    {try { 
      PhoneDialer.Open("15557432222");

      }
      catch (ArgumentNullException anEx)
      {
        // Number was null or white space
      }
      catch (FeatureNotSupportedException ex)
      {
        // Phone Dialer is not supported on this device.
      }
      catch (Exception ex)
      {
        // Other error has occurred.
      }
    }

    void EmailerClicked(System.Object sender, System.EventArgs e)
    {
      List<string> recipients = new List<string>();
      string useremail = "test@gmail.com";
      recipients.Add(useremail);
      try
      {
        var message = new EmailMessage
        {
          //Subject = subject,
          //Body = body,
          To = recipients
          //Cc = ccRecipients,
          //Bcc = bccRecipients
        };
        Email.ComposeAsync(message);
      }
      catch (Exception ex)
      {
        //Debug.WriteLine("Exception:>>" + ex);
      }
    }
  }
}
