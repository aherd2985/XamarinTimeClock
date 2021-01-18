using System;
using SQLite;

namespace TimeClock.Models
{
  public class EmployeeItem
  {
    [PrimaryKey, AutoIncrement]
    public int EmpID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNbr { get; set; }
    public string Email { get; set; }
    public string MarketNm { get; set; }
    public string Title { get; set; }


    public string DisplayName
    {
      get
      {
        return $"{LastName}, {FirstName}";
      }
    }

    public string DetailLbl
    {
      get
      {
        return $"{Title} - {MarketNm}";
      }
    }
  }
}
