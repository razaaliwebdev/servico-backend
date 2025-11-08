using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Services
    {
        public int id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public string emirates { get; set; }
        public string opentime { get; set; }

        public string closetime { get; set; }

        public string img  { get; set; }
        public string expiry { get; set; }

        public string username { get; set; }
        public string password { get; set; }

        public string catid { get; set; }
        public string subid { get; set; }
        public string catname { get; set; }
        public string subname { get; set; }
        public string phone { get; set; }


       

        public string admin { get; set; }
       

       


    }
}
