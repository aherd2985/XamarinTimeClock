using System;
using System.Collections.Generic;
using TimeClock.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class EmployeeContactPage : ContentPage
  {
    public EmployeeContactPage()
    {
      InitializeComponent();


      Binding newPb = new Binding("HasPhoneNbr");
      callBtn.SetBinding(Button.IsVisibleProperty, newPb);

      newPb = new Binding("HasEmail");
      emailBtn.SetBinding(Button.IsVisibleProperty, newPb);


    }

    void PhoneDialerClicked(System.Object sender, System.EventArgs e)
    {
      try
      {
        EmployeeItem empItem = (EmployeeItem)BindingContext;

        PhoneDialer.Open(empItem.PhoneNbr);

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

      try
      {
        List<string> recipients = new List<string>();
        EmployeeItem empItem = (EmployeeItem)BindingContext;


        recipients.Add(empItem.Email);


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
