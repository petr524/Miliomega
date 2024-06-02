using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Student : User
    {
        public Student(string firstName, string lastName, string username, string password)
            : base(firstName, lastName, username, password)
        {
        }

        // Metoda pro zobrazení úkolů
        public void ViewTasks(TaskManager taskManager)
        {
            taskManager.DisplayTasks();
        }
    }
}
