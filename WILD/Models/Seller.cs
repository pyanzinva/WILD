using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Seller
    {
        public int Seller_ID { get; set; }
        public int IP_Number { get; set; }
        public string Organization_Name { get; set; }
        public string Contact_Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
