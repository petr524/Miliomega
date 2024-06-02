using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;

namespace pvrocnikovka
{


    public class ProfileManager
    {
        private Dictionary<string, UserProfile> profiles;

        public ProfileManager()
        {
            profiles = new Dictionary<string, UserProfile>();
        }

        public void UpdateProfile(string username, string firstName, string lastName, string email, string phoneNumber)
        {
            if (profiles.ContainsKey(username))
            {
                profiles[username].FirstName = firstName;
                profiles[username].LastName = lastName;
                profiles[username].Email = email;
                profiles[username].PhoneNumber = phoneNumber;
            }
            else
            {
                profiles[username] = new UserProfile(firstName, lastName, email, phoneNumber);
            }
        }

        public void DisplayProfile(string username)
        {
            if (profiles.ContainsKey(username))
            {
                var profile = profiles[username];
                Console.WriteLine($"First Name: {profile.FirstName}, Last Name: {profile.LastName}, Email: {profile.Email}, Phone: {profile.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Profil nenalezen.");
            }
        }

        public void SaveProfilesToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var profile in profiles)
                {
                    writer.WriteLine($"{profile.Key}|{profile.Value.FirstName}|{profile.Value.LastName}|{profile.Value.Email}|{profile.Value.PhoneNumber}");
                }
            }
        }

        public void LoadProfilesFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 5)
                        {
                            string username = parts[0];
                            string firstName = parts[1];
                            string lastName = parts[2];
                            string email = parts[3];
                            string phoneNumber = parts[4];
                            profiles[username] = new UserProfile(firstName, lastName, email, phoneNumber);
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

    public class UserProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public UserProfile(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

}