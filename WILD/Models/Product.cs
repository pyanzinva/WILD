using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Product
    {
        public int Product_ID { get; set; }
        public int FK_Seller { get; set; }

        [ForeignKey("FK_Seller")]
        public virtual Seller Seller { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<Ordered_Product> Ordered_Products { get; set; }
    }

}
