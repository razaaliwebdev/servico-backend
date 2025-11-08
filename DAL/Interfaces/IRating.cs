using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface  IRating
    { 
        Task<rating> Addratings(rating rating);
        Task<List<rating>> GetAllratings();

        string Deleteratings(string id);
        rating getbyidratings(string id);
    }
}
