using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TimeClock.Data;
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

      SadDataBuild sadData = new SadDataBuild();
      sadData.SetSadDataBuildEmployees();



    }


  }
}
