using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pvrocnikovka
{
    public class Notification
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public Notification(string recipient, string message)
        {
            Recipient = recipient;
            Message = message;
            Timestamp = DateTime.Now;
        }
    }
}
