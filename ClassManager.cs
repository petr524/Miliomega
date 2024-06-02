using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class ClassManager
    {
        private Dictionary<string, List<Student>> classes;

        public ClassManager()
        {
            classes = new Dictionary<string, List<Student>>();
        }

        public void AddStudentToClass(string className, Student student)
        {
            if (!classes.ContainsKey(className))
            {
                classes[className] = new List<Student>();
            }
            classes[className].Add(student);
        }

        public void DisplayStudentsInClass(string className)
        {
            if (classes.ContainsKey(className))
            {
                Console.WriteLine($"Seznam studentů ve třídě {className}:");
                foreach (var student in classes[className])
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }
            }
            else
            {
                Console.WriteLine($"Třída {className} neexistuje.");
            }
        }
    }
}
