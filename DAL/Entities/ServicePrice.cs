using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Entities
{
    public class ServicePrice
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string staffless { get; set; }
        public string staffmore { get; set; }


        public string categoryname { get; set; }
        public string subcategoryname { get; set; }
        public string servicename { get; set; }
        public string servicecompanyname { get; set; }
        public string servicecompanyid { get; set; }


        public string price { get; set; }
       
       


      
    }
}
