using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace TimeClock.Views
{
  public partial class SyncDataPage : ContentPage
  {
    public SyncDataPage()
    {
      InitializeComponent();
    }

    
    void SyncClicked(System.Object sender, System.EventArgs e)
    {

      string messageContent = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contactList.json");


      using (StreamWriter streamWriter = new StreamWriter(messageContent, true))
      {
        streamWriter.WriteLine(DateTime.UtcNow);



        //JsonSerializer serializer = new JsonSerializer();
        //serialize object directly into file stream
        //serializer.Serialize(streamWriter, "poop");


      }



    }


  }
}
