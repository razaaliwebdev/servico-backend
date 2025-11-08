using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IVehicle
    {
        Task<Vehicle> Add(string id, string category, string make, string model, string year, string numberplate);
        Task<List<Vehicle>> GetAll();

        string Delete(string id);
        Vehicle getbyid(string id);
        Task<Vehicle> Update(string id, string category, string make, string model, string year, string numberplate);

    }
}
