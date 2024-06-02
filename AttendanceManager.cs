using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{
    public class AttendanceManager
    {
        private List<Attendance> attendances;

        public AttendanceManager()
        {
            attendances = new List<Attendance>();
        }

        public void MarkAttendance(string username, DateTime date, bool isPresent)
        {
            attendances.Add(new Attendance(username, date, isPresent));
        }

        public void DisplayAttendance(string username)
        {
            Console.WriteLine($"Docházka pro {username}:");
            foreach (var attendance in attendances)
            {
                if (attendance.Username == username)
                {
                    Console.WriteLine($"Datum: {attendance.Date}, Přítomen: {attendance.IsPresent}");
                }
            }
        }

        public void SaveAttendanceToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var attendance in attendances)
                {
                    writer.WriteLine($"{attendance.Username}|{attendance.Date}|{attendance.IsPresent}");
                }
            }
        }

        public void LoadAttendanceFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            string username = parts[0];
                            DateTime date = DateTime.Parse(parts[1]);
                            bool isPresent = bool.Parse(parts[2]);
                            attendances.Add(new Attendance(username, date, isPresent));
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
