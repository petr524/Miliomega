using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Subject
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Subject(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
