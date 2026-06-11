using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace ClassLibrary.Users
{
    public class Staff : User
    {
        [JsonConstructor]
        public Staff(string name, string email, string password, string photo, Role role) : base(name, email, password, photo) { }
    }
}
