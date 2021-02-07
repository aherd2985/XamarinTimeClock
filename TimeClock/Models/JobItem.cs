using SQLite;
using System;

namespace TimeClock.Models
{
  public class JobItem
  {
    [PrimaryKey, AutoIncrement]
    public int JobID { get; set; }
    public string JobCode { get; set; }
    public string JobAddress { get; set; }
  }
}
