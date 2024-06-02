using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{
    public class NotificationManager
    {
        private List<Notification> notifications;

        public NotificationManager()
        {
            notifications = new List<Notification>();
        }

        public void AddNotification(string recipient, string message)
        {
            notifications.Add(new Notification(recipient, message));
        }

        public void DisplayNotifications(string username)
        {
            Console.WriteLine($"Notifikace pro {username}:");
            foreach (var notification in notifications)
            {
                if (notification.Recipient == username)
                {
                    Console.WriteLine($"Čas: {notification.Timestamp}, Zpráva: {notification.Message}");
                }
            }
        }

        public void SaveNotificationsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var notification in notifications)
                {
                    writer.WriteLine($"{notification.Recipient}|{notification.Message}|{notification.Timestamp}");
                }
            }
        }

        public void LoadNotificationsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            string recipient = parts[0];
                            string message = parts[1];
                            DateTime timestamp = DateTime.Parse(parts[2]);
                            notifications.Add(new Notification(recipient, message) { Timestamp = timestamp });
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
