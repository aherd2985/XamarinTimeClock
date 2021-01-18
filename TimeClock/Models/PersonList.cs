using System.Collections.Generic;

namespace TimeClock.Models
{
  public class PersonList : List<EmployeeItem>
  {
    public string Heading { get; set; }
    public List<EmployeeItem> Persons => this;
  }
}
