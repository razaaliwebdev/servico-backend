using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Blogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int blogid { get; set; }

        public string title { get; set; }

        public string image { get; set; }
        public string desc { get; set; }

        public string metatitle { get; set; }

        public string metdesc { get; set; }
        public string keywords { get; set; }


    }
}
