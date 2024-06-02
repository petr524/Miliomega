using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Attendance
    {
        public string Username { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public Attendance(string username, DateTime date, bool isPresent)
        {
            Username = username;
            Date = date;
            IsPresent = isPresent;
        }
    }
}
