using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISubCategories
    {
        Task<Subcategories> AddCategories(string name,string id, string categoryid, string categoryname);
        Task<List<Subcategories>> GetAllCategories();

        string DeleteCategories(string id);
        Subcategories getbyidCategories(string id);
        Task<Subcategories> UpdateCategories(string name, string id,string categoryid,string categoryname);
    }
}
