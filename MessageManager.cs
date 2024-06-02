using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pvrocnikovka
{

    public class MessageManager
    {
        private List<Message> messages;

        public MessageManager()
        {
            messages = new List<Message>();
        }

        public void SendMessage(string sender, string recipient, string content)
        {
            messages.Add(new Message(sender, recipient, content));
        }

        public void DisplayMessages(string username)
        {
            Console.WriteLine($"Zprávy pro {username}:");
            foreach (var message in messages)
            {
                if (message.Recipient == username)
                {
                    string readStatus = message.IsRead ? "Přečteno" : "Nepřečteno";
                    Console.WriteLine($"Od: {message.Sender}, Čas: {message.Timestamp}, Zpráva: {message.Content}, Status: {readStatus}");
                }
            }
        }

        public void MarkMessageAsRead(string username, int messageIndex)
        {
            int index = 0;
            foreach (var message in messages)
            {
                if (message.Recipient == username)
                {
                    if (index == messageIndex)
                    {
                        message.MarkAsRead();
                        Console.WriteLine("Zpráva byla označena jako přečtená.");
                        return;
                    }
                    index++;
                }
            }
            Console.WriteLine("Zpráva nebyla nalezena.");
        }

        public void SaveMessagesToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var message in messages)
                {
                    writer.WriteLine($"{message.Sender}|{message.Recipient}|{message.Content}|{message.Timestamp}|{message.IsRead}");
                }
            }
        }

        public void LoadMessagesFromFile(string filePath)
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
                            string sender = parts[0];
                            string recipient = parts[1];
                            string content = parts[2];
                            DateTime timestamp = DateTime.Parse(parts[3]);
                            bool isRead = bool.Parse(parts[4]);
                            messages.Add(new Message(sender, recipient, content) { Timestamp = timestamp, IsRead = isRead });
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
