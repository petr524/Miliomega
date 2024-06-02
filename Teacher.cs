using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Teacher : User
    {
        public Teacher(string firstName, string lastName, string username, string password)
            : base(firstName, lastName, username, password)
        {
        }

        public void CreateTask(TaskManager taskManager, string title, string description, DateTime dueDate)
        {
            taskManager.AddTask(title, description, dueDate);
            Console.WriteLine($"Nový úkol \"{title}\" byl vytvořen.");
        }
    }
}
