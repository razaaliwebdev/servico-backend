using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Ityrebrand
    {
        Task<tyrebrand> Add(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel);
        Task<List<tyrebrand>> GetAll();

        string Delete(string id);
        tyrebrand getbyid(string id);
        Task<tyrebrand> Update(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel);

    }
}
