using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{
    public class GradeManager
    {
        private Dictionary<string, int> grades;

        public GradeManager()
        {
            grades = new Dictionary<string, int>();
        }

        public void AddGrade(string task, int grade)
        {
            grades[task] = grade;
        }

        public int GetGrade(string task)
        {
            if (grades.ContainsKey(task))
            {
                return grades[task];
            }
            else
            {
                return -1;
            }
        }

        public void SaveGradesToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var grade in grades)
                {
                    writer.WriteLine($"{grade.Key}|{grade.Value}");
                }
            }
        }

        public void LoadGradesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 2)
                        {
                            string task = parts[0];
                            int grade = int.Parse(parts[1]);
                            grades[task] = grade;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
        }

        public List<int> GetAllGrades()
        {
            return grades.Values.ToList();
        }
    }
}
