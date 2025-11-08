using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Entities
{
    public class metamain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string metatitle { get; set; }

        public string metadesc { get; set; }

        public string metakeyword { get; set; }
        public string bnum { get; set; }

    }
}
