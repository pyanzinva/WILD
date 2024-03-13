using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Order
    {
        public int Order_ID { get; set; }
        public int FK_Client { get; set; }

        [ForeignKey("FK_Client")]
        public virtual Client Client { get; set; }

        public DateTime Order_Date { get; set; }
        public virtual ICollection<Ordered_Product> Ordered_Products { get; set; }
    }
}
