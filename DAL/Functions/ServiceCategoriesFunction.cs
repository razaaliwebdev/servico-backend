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
    public class ServiceCategoriesFunction : IServiceCategories
    {
        public async Task<ServiceCategories> AddCategories(string name, string slug,string image)
        {
            ServiceCategories newUser = new ServiceCategories

            {
                name = name,
                slug = slug,
                image = image



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.servicecategoriess.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

    

        public async Task<List<ServiceCategories>> GetAllCategories()
        {
            List<ServiceCategories> categories = new List<ServiceCategories>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.servicecategoriess.OrderByDescending(s => s.id).ToListAsync();

            }
            return categories;
        }

        public async Task<ServiceCategories> UpdateCategories(string name, string id, string slug,string image)
        {
            ServiceCategories newUser = new ServiceCategories

            {
                name = name,
                slug = slug,
                image=image


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.servicecategoriess.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.name = name;
                get.slug = slug;
                get.image = image;
                context.servicecategoriess.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public ServiceCategories getbyidCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.servicecategoriess.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string DeleteCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.servicecategoriess.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
