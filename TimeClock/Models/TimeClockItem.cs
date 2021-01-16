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
    public string gpsLatitude { get; set; }
    public string gpsLongitude { get; set; }
    public DateTimeOffset? gpsLastTimestamp { get; set; }
    public string gpsDetail { get; set; }
    public bool IsClockIn { get; set; }
  }
}
