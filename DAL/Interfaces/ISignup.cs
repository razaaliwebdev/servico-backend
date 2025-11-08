using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISignup
    {
        Task<Signup> AddSignup(string firstname, string lastname, string email, string phone, string password, string type, string document1, string document2, string extra,string verification);
        Task<List<Signup>> GetAllSignup();

        string DeleteSignup(string id);
        Signup getbyidSignup(string id);
        Task<Signup> UpdateSignup(string id, string firstname, string lastname, string email, string phone, string password, string type, string document1, string document2, string extra, string verification);

        Signup GetLogin(Signup obj);

        string ForgotPassword(Signup obj);
    }
}
