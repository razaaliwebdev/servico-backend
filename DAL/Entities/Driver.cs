using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string opentime { get; set; }
        public string closetime { get; set; }
        public string expiry { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string vid { get; set; }
      
    }
}
