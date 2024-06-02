using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{

    public class SubjectManager
    {
        private List<Subject> subjects;

        public SubjectManager()
        {
            subjects = new List<Subject>();
        }

        public void AddSubject(string name, string code)
        {
            subjects.Add(new Subject(name, code));
        }

        public void DisplaySubjects()
        {
            Console.WriteLine("Seznam předmětů:");
            foreach (var subject in subjects)
            {
                Console.WriteLine($"Name: {subject.Name}, Code: {subject.Code}");
            }
        }

        public void SaveSubjectsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var subject in subjects)
                {
                    writer.WriteLine($"{subject.Name}|{subject.Code}");
                }
            }
        }

        public void LoadSubjectsFromFile(string filePath)
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
                            string name = parts[0];
                            string code = parts[1];
                            subjects.Add(new Subject(name, code));
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
