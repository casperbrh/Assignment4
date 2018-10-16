using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment4
{
    [Table("categories")]
    public class Category
    {
        [Column("categoryid")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
