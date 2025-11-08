using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class CategoriesFunction :ICategories
    {
        public async Task<Categories> AddCategories(string name,string slug)
        {
            Categories newUser = new Categories

            {
                name = name,
                slug = slug


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.categories.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

   

        public async Task<List<Categories>> GetAllCategories()
        {
            List<Categories> categories = new List<Categories>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.categories.OrderByDescending(s => s.Categories_ID).ToListAsync();

            }
            return categories;
        }

        public async Task<Categories> UpdateCategories(string name,string id,string slug)
        {
            Categories newUser = new Categories

            {
                name = name,
                slug = slug


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.categories.FirstOrDefault(x=>x.Categories_ID == Convert.ToInt64(id));
                get.name = name;
                get.slug = slug;
                 context.categories.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }
        

       public Categories getbyidCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.categories.FirstOrDefault(x => x.Categories_ID == Convert.ToInt64(id));

                return getbyID; 


            }
        }
        public  string DeleteCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.categories.FirstOrDefault(x => x.Categories_ID == Convert.ToInt64(id));
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

      
    }
}
