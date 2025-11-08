using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface ITyreBrandImages
    {
        Task<Tyrebrandimage> AddBrands(string name,  string image);
        Task<List<Tyrebrandimage>> GetAllBrands();
        string DeleteBrands(string name);
        Tyrebrandimage getbyidBrands(string id);
        Task<Tyrebrandimage> UpdateBrands(string name, string id, string image);
    }
}

