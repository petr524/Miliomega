using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // Konstruktor pro vytvoření instance uživatele
        public User(string firstName, string lastName, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        // Metoda pro registraci nového uživatele
        public static User Register()
        {
            Console.WriteLine("Registrace nového uživatele");
            Console.Write("Zadejte křestní jméno: ");
            string firstName = Console.ReadLine();
            Console.Write("Zadejte příjmení: ");
            string lastName = Console.ReadLine();
            Console.Write("Zadejte uživatelské jméno: ");
            string username = Console.ReadLine();
            Console.Write("Zadejte heslo: ");
            string password = Console.ReadLine();

            return new User(firstName, lastName, username, password);
        }
    }

}
