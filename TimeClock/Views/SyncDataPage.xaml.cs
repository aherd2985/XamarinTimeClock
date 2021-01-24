using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TimeClock.Models;
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






      List<EmployeeItem> userList = JsonConvert.DeserializeObject<List<EmployeeItem>>(File.ReadAllText(messageContent));




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
