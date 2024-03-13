using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Pickup_Point
    {
        public int Pickup_Point_ID { get; set; }
        public string Settlement { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public int FK_Ordered_Product { get; set; }

        [ForeignKey("FK_Ordered_Product")]
        public virtual Ordered_Product Ordered_Product { get; set; }

        public int Number_of_Orders { get; set; }
        public decimal Pickup_Point_Rating { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
