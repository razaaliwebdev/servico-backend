using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Subcategories
    {
        [Key]
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Subid { get; set; }
        public string name { get; set; }

        public string categoryname { get; set; }
        [ForeignKey("Categories_ID")]

        public int? category_id { get; set; }

        public Categories? Categories { get; set; }

    }
}
