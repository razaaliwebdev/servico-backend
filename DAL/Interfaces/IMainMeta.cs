using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMainMeta
    {
        Task<metamain> Addmetamains(string bnum, string metatitle, string metadesc, string metakeyword);
        Task<List<metamain>> GetAllmetamains();
        string Deletemetamains(string name);
        metamain getbyidmetamains(string id);
        Task<metamain> Updatemetamains(string id,string bnum, string metatitle, string metadesc, string metakeyword);
    }
}
