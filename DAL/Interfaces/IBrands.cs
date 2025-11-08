using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBrands
    {
        Task<Brands> AddBrands(string name,string desc, string image);
        Task<List<Brands>> GetAllBrands();
        string DeleteBrands(string name);
        Brands getbyidBrands(string id);
        Task<Brands> UpdateBrands(string name,string id, string desc, string image);
    }
}
