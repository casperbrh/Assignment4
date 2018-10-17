using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    [Table("products")]
    public class Product
    {
        [Column("productid")]
        public int Id { get; set; }

        [Column("productname")]
        public string Name { get; set; }

        [Column("categoryid")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Column("unitprice")]
        public double UnitPrice { get; set; }
        public String QuantityPerUnit { get; set; }

        [Column("unitsinstock")]
        public int UnitsInStock { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        
    }
}