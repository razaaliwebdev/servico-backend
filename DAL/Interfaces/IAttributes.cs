using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IAttributes
    {
        Task<Attributes> AddAttributes(string name);
        Task<List<Attributes>> GetAllAttributes();
        string DeleteAttributes(string name);
        Attributes getbyidAttributes(string id);
        Task<Attributes> UpdateAttributes(string name,string id);

    }
}
