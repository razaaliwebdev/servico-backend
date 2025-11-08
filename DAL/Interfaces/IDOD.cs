using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Interfaces
{
    public interface IDOD
    {
        Task<DOD> AddBanners(string bnum, string image, string value, string productid, string type,string details,string dealcounter,string price);
        Task<List<DOD>> GetAllBanners();
        string DeleteBanners(string name);
        DOD getbyidBanners(string id);
        Task<DOD> UpdateBanners(string id, string bnum, string image, string value, string productid, string type, string details, string dealcounter,string price);
    }
}
