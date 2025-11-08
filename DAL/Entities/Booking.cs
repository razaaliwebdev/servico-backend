using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Booking
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string code { get; set; }

        public string categoryname { get; set; }
        public string subcategoryname { get; set; }

        public string location { get; set; }
        public string servicetype { get; set; }
        public string year  { get; set; }
        public string carmake { get; set; }
        public string carmodel { get; set; }
        public string bodytype { get; set; }
        public string fueltype { get; set; }
        public string problemtofix { get; set; }
        public string transactionnumber { get; set; }
        public string washtype { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }

        public string customerid { get; set; }



        public string shopid { get; set; }
    }
}
