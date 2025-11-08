using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace LOGIC.SettingsLogic
{
    public class BlogsLogic 
    {

        private IBLogs _Blogs = new DAL.Functions.BlogsFunction();
        public async Task<Boolean> CreateNewBlogs(string id ,string title, string image, string desc, string metatitle, string metadesc, string keywords)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Blogs.UpdateBlogs(id, title,  image,  desc, metatitle, metadesc, keywords);
                    if (get.Id > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    var result = await _Blogs.AddBlogs(title, image, desc, metatitle, metadesc, keywords);
                    if (result.blogid > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception error)
            {
                return false;
            }
        }

        public async Task<List<Blogs>> GetAllBlogs()
        {
            List<Blogs> getlist = await _Blogs.GetAllBlogs();
            return getlist;
        }
        public string DeleteBlogs(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Blogs.DeleteBlogs(id);

                return "true";
            }
            else
            {
                return "false";
            }

        }
        public Blogs getbyidBlogs(string id)
        {

            var get = _Blogs.getbyidBlogs(id);

            return get;


        }
    }
}
