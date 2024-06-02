using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Message
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }

        public Message(string sender, string recipient, string content)
        {
            Sender = sender;
            Recipient = recipient;
            Content = content;
            Timestamp = DateTime.Now;
            IsRead = false;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}