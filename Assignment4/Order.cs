using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{   [Table("order")]
    public class Order
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("required")]
        public DateTime Required { get; set; }

        [Column("shipname")]
        public String ShipName { get; set; }

        [Column("shipcity")]
        public String ShipCity { get; set; }

        [Column("orderdetails")]
        public List<OrderDetails> OrderDetails { get; set; }
    }
}