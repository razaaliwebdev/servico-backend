using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBanners
    {
        Task<Banners> AddBanners(string bnum, string image,string value, string productid,string type);
        Task<List<Banners>> GetAllBanners();
        string DeleteBanners(string name);
        Banners getbyidBanners(string id);
        Task<Banners> UpdateBanners(string id, string bnum, string image, string value, string productid,string type);
    }
}
