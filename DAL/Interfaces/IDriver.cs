using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDriver
    {
        Task<Driver> Add(string id, string name, string image, string opentime, string closetime, string expiry,string email,string password,string vid);
        Task<List<Driver>> GetAll();

        string Delete(string id);
        Driver getbyid(string id);
        Task<Driver> Update(string id, string name, string image, string opentime, string closetime, string expiry, string email, string password, string vid);

    }
}
