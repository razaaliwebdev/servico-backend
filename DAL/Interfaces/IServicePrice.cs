using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Interfaces
{
  public  interface IServicePrice
    {
        Task<ServicePrice> Add(string id, string staffless, string staffmore, string categoryname, string subcategoryname, string servicename, string servicecompanyname,string servicecompanyid,string price);
        Task<List<ServicePrice>> GetAll();

        string Delete(string id);
        ServicePrice getbyid(string id);
        Task<ServicePrice> Update( string id, string staffless, string staffmore, string categoryname, string subcategoryname, string servicename, string servicecompanyname, string servicecompanyid, string price);
    }
}
