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
    public class Carfilters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string year { get; set; }
        public string make { get; set; }
        public string model { get; set; }

        public string bodytype { get; set; }
        public string fueltype { get; set; }
        public string makeimage { get; set; }




    }
}
