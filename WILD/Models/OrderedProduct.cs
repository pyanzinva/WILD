using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Ordered_Product
    {
        public int Ordered_Product_ID { get; set; }
        public int FK_Order { get; set; }
        public int FK_Product { get; set; }

        [ForeignKey("FK_Order")]
        public virtual Order Order { get; set; }

        [ForeignKey("FK_Product")]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        public DateTime Shipping_Date { get; set; }

        public virtual ICollection<Pickup_Point> Pickup_Points { get; set; }
    }
}
