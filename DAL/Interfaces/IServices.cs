using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface  IServices
    {
        Task<Services> AddServices(string id ,string title, string type, string location,string emirates,string opentime,string closetime, string img, string expiry,string adminid, string Categories_ID, string categoryname, string SubCategoryid, string subcategoryname, string username, string password,string phone);
        Task<List<Services>> GetAllServices();
        string DeleteServices(string name);
        Services getbyidServices(string id);
        Task<Services> UpdateServices(string id,string title, string type, string location, string emirates, string opentime, string closetime, string img, string expiry, string adminid, string Categories_ID, string categoryname, string SubCategoryid, string subcategoryname, string username, string password,string phone);
    }
}
