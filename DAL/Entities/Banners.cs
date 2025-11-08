using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Banners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int banner_ID { get; set; }

        public string bnum { get; set; }

        public string image { get; set; }
        public string value { get; set; }

        public string productid { get; set; }

        public string type { get; set; }



    }
}
