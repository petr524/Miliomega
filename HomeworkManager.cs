using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{
    public class HomeworkManager
    {
        private List<Homework> homeworks;

        public HomeworkManager()
        {
            homeworks = new List<Homework>();
        }

        public void AddHomework(string title, string description, DateTime dueDate)
        {
            homeworks.Add(new Homework(title, description, dueDate));
        }

        public void DisplayHomeworks()
        {
            Console.WriteLine("Seznam domácích úkolů:");
            foreach (var homework in homeworks)
            {
                Console.WriteLine($"Název: {homework.Title}, Popis: {homework.Description}, Termín: {homework.DueDate}");
            }
        }

        public void SaveHomeworksToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var homework in homeworks)
                {
                    writer.WriteLine($"{homework.Title}|{homework.Description}|{homework.DueDate}");
                }
            }
        }

        public void LoadHomeworksFromFile(string filePath)
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
                            string title = parts[0];
                            string description = parts[1];
                            DateTime dueDate = DateTime.Parse(parts[2]);
                            homeworks.Add(new Homework(title, description, dueDate));
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
