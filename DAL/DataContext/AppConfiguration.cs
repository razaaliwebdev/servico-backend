using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.DataContext
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(),"appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            var appsetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlconnectionstring = appsetting.Value;




        }

        public string sqlconnectionstring {get;set;}
    }
}
