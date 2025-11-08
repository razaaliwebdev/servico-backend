using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Signup
    {
        public int id { get; set; }
        public string firstname  { get; set; }
        public string lastname  { get; set; }
        public string email  { get; set; }
        public string phone  { get; set; }
        public string password  { get; set; }
        public string type  { get; set; }
        public string document1  { get; set; }
        public string document2  { get; set; }

        public string extra { get; set; }



        public string verification { get; set; }
    }
}
