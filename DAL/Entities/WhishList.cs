using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class WhishList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int whishid { get; set; }

        [ForeignKey("Product_ID")]
        public int? product_id { get; set; }

        public Product? Products { get; set; }

        [ForeignKey("Id")]
        public int? id { get; set; }

        public Signup? signup { get; set; }
    }
}
