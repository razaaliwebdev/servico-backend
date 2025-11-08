using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class tyrebrand
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string countrybrand { get; set; }
        public string countrymade { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string rimsize { get; set; }
        public string tyremodel { get; set; }

    }
}
