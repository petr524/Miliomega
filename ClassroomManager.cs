using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{
    public class ClassroomManager
    {
        private List<Classroom> classrooms;

        public ClassroomManager()
        {
            classrooms = new List<Classroom>();
        }

        public void AddClassroom(string name, string location)
        {
            classrooms.Add(new Classroom(name, location));
        }

        public void DisplayClassrooms()
        {
            Console.WriteLine("Seznam učeben:");
            foreach (var classroom in classrooms)
            {
                Console.WriteLine($"Name: {classroom.Name}, Location: {classroom.Location}");
            }
        }

        public void SaveClassroomsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var classroom in classrooms)
                {
                    writer.WriteLine($"{classroom.Name}|{classroom.Location}");
                }
            }
        }

        public void LoadClassroomsFromFile(string filePath)
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
                            string location = parts[1];
                            classrooms.Add(new Classroom(name, location));
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
