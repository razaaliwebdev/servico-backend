using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
  public  interface  IServiceCategories
    {
        Task<ServiceCategories> AddCategories(string name, string slug, string image);
        Task<List<ServiceCategories>> GetAllCategories();

        string DeleteCategories(string id);
        ServiceCategories getbyidCategories(string id);
        Task<ServiceCategories> UpdateCategories(string name, string id, string slug,string image);
    }
}
