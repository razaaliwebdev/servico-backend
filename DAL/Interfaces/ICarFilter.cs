using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface  ICarFilter
    {
        Task<Carfilters> Add(string id,string year, string make,string model,string bodytype,string fueltype,string makeimage);
        Task<List<Carfilters>> GetAll();

        string Delete(string id);
        Carfilters getbyid(string id);
        Task<Carfilters> Update(string id, string year, string make, string model, string bodytype, string fueltype,string makeimage);

    }
}
