using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{
    public class ScheduleManager
    {
        private List<Schedule> schedules;

        public ScheduleManager()
        {
            schedules = new List<Schedule>();
        }

        public void AddSchedule(string className, string subject, DateTime startTime, DateTime endTime)
        {
            schedules.Add(new Schedule(className, subject, startTime, endTime));
        }

        public void DisplaySchedules()
        {
            Console.WriteLine("Seznam rozvrhů:");
            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Class: {schedule.ClassName}, Subject: {schedule.Subject}, Start: {schedule.StartTime}, End: {schedule.EndTime}");
            }
        }

        public void SaveSchedulesToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var schedule in schedules)
                {
                    writer.WriteLine($"{schedule.ClassName}|{schedule.Subject}|{schedule.StartTime}|{schedule.EndTime}");
                }
            }
        }

        public void LoadSchedulesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 4)
                        {
                            string className = parts[0];
                            string subject = parts[1];
                            DateTime startTime = DateTime.Parse(parts[2]);
                            DateTime endTime = DateTime.Parse(parts[3]);
                            schedules.Add(new Schedule(className, subject, startTime, endTime));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
        }
    }
}
