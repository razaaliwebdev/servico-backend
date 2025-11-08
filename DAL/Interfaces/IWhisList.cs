using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Interfaces
{
    public interface IWhisList
    {
        Task<WhishList> Create(string Whishid, string Product_ID,string id);
        Task<List<WhishList>> GetAll();

        string Delete(string Whishid,string userid);
        WhishList getbyid(string Whishid);
        
    }
}
