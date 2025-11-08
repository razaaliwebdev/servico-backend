using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ServiceSubcategories
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }

        public string categoryname { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string adminid { get; set; }

        [ForeignKey("Categories_ID")]

        public int? category_id { get; set; }

        public Categories? Categories { get; set; }
    }
}
