using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Attributes
    {
        [Key]
        public  int AttributeID { get; set; }

        public string name { get; set; }
    }
}
