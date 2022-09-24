using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.Models
{
    public class Message
    {
        public Message()
        {

        }
        public Message(string sender, string receiver, string text, DateTime date)
        {
            Sender = sender;
            Receiver = receiver;
            Text = text;
            Date = date;
        }

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

    }
}
