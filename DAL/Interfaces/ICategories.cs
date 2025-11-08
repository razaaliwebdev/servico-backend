using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategories
    {
        Task<Categories> AddCategories(string name,string slug);
        Task<List<Categories>> GetAllCategories();

        string DeleteCategories(string  id);
        Categories getbyidCategories(string id);
        Task<Categories> UpdateCategories(string name,string id,string slug);
    }
}
