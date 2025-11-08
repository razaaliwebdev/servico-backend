using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderItems
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItems_ID { get; set; }
        public string name { get; set; }
        public string quantity  { get; set; }
        public string cbm { get; set; }
        public string qtyordered { get; set; }
        public string price { get; set; }

        public string singleimage { get; set; }

        public string Product_ID_custom { get; set; }
        public string order_ID_custom { get; set; }


        [ForeignKey("Product_ID")]

        public int? product_id { get; set; }

        public Product? Products { get; set; }

        [ForeignKey("order_ID")]

        public int order_id { get; set; }

        public Orders? Orders { get; set; }




    }
}
