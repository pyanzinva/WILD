using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WILD.Models
{
    public class Employee
    {
        public int Employee_ID { get; set; }
        public int FK_Pickup_Point { get; set; }

        [ForeignKey("FK_Pickup_Point")]
        public virtual Pickup_Point Pickup_Point { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Number_Series { get; set; }
        public decimal Salary { get; set; }
    }
}
