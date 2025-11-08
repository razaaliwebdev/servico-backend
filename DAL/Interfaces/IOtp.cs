using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOtp
    {
        Task<Otp> AddOtp(string email, string code);
        Task<List<Otp>> GetAllOtp();
        string DeleteOtp(string name);
        Otp getbyidOtp(string id);
        Task<Otp> UpdateOtp(string email, string id, string code);
    }
}
