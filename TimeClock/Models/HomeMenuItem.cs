using System;
using System.Collections.Generic;
using System.Text;

namespace TimeClock.Models
{
  public enum MenuItemType
  {
    About,
    TimeClock
  }
  public class HomeMenuItem
  {
    public MenuItemType Id { get; set; }

    public string Title { get; set; }
  }
}