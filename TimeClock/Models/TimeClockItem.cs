using SQLite;
using System;

namespace TimeClock
{
  public class TimeClockItem
  {
    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string Notes { get; set; }
    public bool IsMock { get; set; }
    public DateTime TimePunch { get; set; }
    public string gpsLocation { get; set; }
    public string gpsDetail { get; set; }
  }
}
