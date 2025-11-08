using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAdminUsers
    {
        Task<AdminUsers> AddSignup(string name, string type,string password);
        Task<List<AdminUsers>> GetAllSignup();

        string DeleteSignup(string id);
        AdminUsers getbyidSignup(string id);
        Task<AdminUsers> UpdateSignup(string id, string name, string type, string password);

        AdminUsers GetLogin(AdminUsers obj);
    }
}
