using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Client
    {
        public int Client_ID { get; set; }
        public string Client_Login { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; } 
        public string Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
