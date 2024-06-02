using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        public Task(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = "Assigned";
        }

        public void MarkAsCompleted()
        {
            Status = "Completed";
        }

        public void MarkAsOverdue()
        {
            Status = "Overdue";
        }
    }
}
