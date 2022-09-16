using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrot.Models {
    public abstract class User {
        string Name { get; set; }
        string Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        List<string> Friends { get; set; }
    }
}
