using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Interfaces
{
  public  interface  IServiceSubcategories
    {
        Task<ServiceSubcategories> AddCategories(string name, string id, string categoryid, string categoryname,string price, string image,string adminid);
        Task<List<ServiceSubcategories>> GetAllCategories();

        string DeleteCategories(string id);
        ServiceSubcategories getbyidCategories(string id);
        Task<ServiceSubcategories> UpdateCategories(string name, string id, string categoryid, string categoryname,string price, string image,string adminid);
    }
}
