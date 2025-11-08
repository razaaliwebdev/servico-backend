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
    public class SubCategoriesFunction : ISubCategories
    {
        public async Task<Subcategories> AddCategories(string name, string id, string categoryid, string categoryname)
        {
            Subcategories newUser = new Subcategories

            {
                name = name,
                category_id=Convert.ToInt16(categoryid),
                categoryname=categoryname



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.subcategoriess.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Subcategories>> GetAllCategories()
        {
            List<Subcategories> categories = new List<Subcategories>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.subcategoriess.ToListAsync();

            }
            return categories;
        }

        public async Task<Subcategories> UpdateCategories(string name, string id, string categoryid, string categoryname)
        {
            Subcategories newUser = new Subcategories

            {

                name = name,
                category_id = Convert.ToInt16(categoryid),
                categoryname = categoryname




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.subcategoriess.FirstOrDefault(x => x.Subid == Convert.ToInt64(id));
                get.name = name;
                context.subcategoriess.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public Subcategories getbyidCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.subcategoriess.FirstOrDefault(x => x.Subid == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string DeleteCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.subcategoriess.FirstOrDefault(x => x.Subid == Convert.ToInt64(id));
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
