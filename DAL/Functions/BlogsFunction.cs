using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace DAL.Functions
{
    public class BlogsFunction :IBLogs
    {

        public async Task<Blogs> AddBlogs(string title, string image, string desc, string metatitle, string metadesc, string keywords)
        {
            Blogs newUser = new Blogs

            {
                title = title,
                image = image,
                desc = desc,
                metatitle = metatitle,
                metdesc = metadesc,
                keywords=keywords



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.Blogss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Blogs>> GetAllBlogs()
        {
            List<Blogs> Blogs = new List<Blogs>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Blogs = await context.Blogss.ToListAsync();

            }
            return Blogs;
        }

        public async Task<Blogs> UpdateBlogs(string id,string title, string image, string desc, string metatitle, string metadesc, string keywords)
        {
            Blogs newUser = new Blogs

            {
                blogid = Convert.ToInt32(id),
                title = title,
                image = image,
                desc = desc,
                metatitle = metatitle,
                metdesc = metadesc,
                keywords = keywords

            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.Blogss.FirstOrDefault(x => x.blogid == Convert.ToInt64(id));
                get.title = title;
                get.image = image;
                get.desc = desc;
                get.metatitle = metatitle;
                get.metdesc = metadesc;
                get.keywords = keywords;
                context.Blogss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteBlogs(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.Blogss.FirstOrDefault(x => x.blogid == Convert.ToInt64(id));
                if (getbyID != null)
                {
                    context.Remove(getbyID);
                    context.SaveChanges();


                    return "true";

                }
                else
                {
                    return "false";
                }



            }
        }
        public Blogs getbyidBlogs(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.Blogss.FirstOrDefault(x => x.blogid == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
