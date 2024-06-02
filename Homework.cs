using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Homework
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public Homework(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
        }
    }
}
