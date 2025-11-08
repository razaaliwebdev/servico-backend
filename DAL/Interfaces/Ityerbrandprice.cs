using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Interfaces
{
    public interface Ityerbrandprice
    {
        Task<tyrebrandprice> Add(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel,string price);
        Task<List<tyrebrandprice>> GetAll();

        string Delete(string id);
        tyrebrandprice getbyid(string id);
        Task<tyrebrandprice> Update(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel,string price);
    }
}
