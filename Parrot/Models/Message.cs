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
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

    }
}
