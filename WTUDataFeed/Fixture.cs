using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTUDataFeed
{
   public class Fixture
   {
      public string? Date { get; set; }
      public string? Home { get; set; }
      public string? Away { get; set; }
      public string? Ground { get; set; }
      public List<Appointment>? Appointments { get; set; }

      public Fixture(string date,  string? home, string? away, string? ground)
      {
         this.Date = date;
         this.Home = home;
         this.Away = away;
         this.Ground = ground; 
         this.Appointments = new List<Appointment>();
      }
   }

   public class Appointment
   {
      public string? Role { get; set; }
      public string? Official { get; set; }

      public Appointment(string? role, string? official)
      {
         Role = role;
         Official = official;
      }
   }
}