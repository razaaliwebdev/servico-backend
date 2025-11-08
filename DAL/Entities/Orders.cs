using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Orders
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_ID { get; set; }
        public string country { get; set; }
        public string firstaname { get; set; }

        public string lastname { get; set; }
        public string companyname { get; set; }
        public string city { get; set; }
        public string zip { get; set; }

        public string state { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }

        public string email { get; set; }

        public string phone { get; set; }
        public string ordernotes { get; set; }
        public string totalcbm { get; set; }
        public string totalprice { get; set; }
        public string datetime { get; set; }

        [ForeignKey("id")]

        public int? id { get; set; }
        public virtual Signup? users { get; set; }

        //   [ForeignKey("orderItems_ID")]

        // public int? orderitems_id { get; set; }

        // public OrderItems? OrderItems { get; set; }

    }
}
