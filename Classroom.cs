using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Classroom
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public Classroom(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}
