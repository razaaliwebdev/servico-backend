using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBLogs
    {
        Task<Blogs> AddBlogs(string title, string image, string desc, string metatitle, string metadesc,string keywords);
        Task<List<Blogs>> GetAllBlogs();
        string DeleteBlogs(string name);
        Blogs getbyidBlogs(string id);
        Task<Blogs> UpdateBlogs(string id, string title, string image, string desc, string metatitle, string metadesc, string keywords);
    }
}
