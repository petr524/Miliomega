using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Schedule
    {
        public string ClassName { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Schedule(string className, string subject, DateTime startTime, DateTime endTime)
        {
            ClassName = className;
            Subject = subject;
            StartTime = startTime;
            EndTime = endTime;
        }
    } 
}
