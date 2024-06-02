using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{

    public class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(string title, string description, DateTime dueDate)
        {
            tasks.Add(new Task(title, description, dueDate));
        }

        public void DisplayTasks()
        {
            Console.WriteLine("Seznam úkolů:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, DueDate: {task.DueDate}, Status: {task.Status}");
            }
        }

        public void MarkTaskAsCompleted(string title)
        {
            var task = tasks.Find(t => t.Title == title);
            if (task != null)
            {
                task.MarkAsCompleted();
                Console.WriteLine($"Úkol \"{title}\" byl označen jako dokončený.");
            }
            else
            {
                Console.WriteLine($"Úkol \"{title}\" nebyl nalezen.");
            }
        }

        public void CheckForOverdueTasks()
        {
            foreach (var task in tasks)
            {
                if (task.DueDate < DateTime.Now && task.Status != "Completed")
                {
                    task.MarkAsOverdue();
                }
            }
        }

        public void SaveTasksToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Title}|{task.Description}|{task.DueDate}|{task.Status}");
                }
            }
        }

        public void LoadTasksFromFile(string filePath)
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
                            string title = parts[0];
                            string description = parts[1];
                            DateTime dueDate = DateTime.Parse(parts[2]);
                            string status = parts[3];
                            tasks.Add(new Task(title, description, dueDate) { Status = status });
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Soubor neexistuje.");
            }
             
        }


        public int GetTotalTasks()
        {
            return tasks.Count;
        }

        public int GetCompletedTasks()
        {
            return tasks.Count(t => t.Status == "Completed");
        }

        public int GetOverdueTasks()
        {
            return tasks.Count(t => t.Status == "Overdue");
        }
    }
}
