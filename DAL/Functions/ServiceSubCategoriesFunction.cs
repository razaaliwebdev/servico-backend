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
    public class  ServiceSubCategoriesFunction : IServiceSubcategories
    {
        public async Task<ServiceSubcategories> AddCategories(string name, string id, string categoryid, string categoryname,string price,string image,string adminid)
        {
            ServiceSubcategories newUser = new ServiceSubcategories

            {
                name = name,
                category_id = Convert.ToInt16(categoryid),
                categoryname = categoryname,
                price=price,
                image=image,
                adminid=adminid

                



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.servicesubcategoriess.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<ServiceSubcategories>> GetAllCategories()
        {
            List<ServiceSubcategories> categories = new List<ServiceSubcategories>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.servicesubcategoriess.ToListAsync();

            }
            return categories;
        }

        public async Task<ServiceSubcategories> UpdateCategories(string name, string id, string categoryid, string categoryname,string price, string image,string adminid)
        {
            ServiceSubcategories newUser = new ServiceSubcategories

            {

                name = name,
                category_id = Convert.ToInt16(categoryid),
                categoryname = categoryname,
                price = price,
                image = image,
                adminid=adminid




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.servicesubcategoriess.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.name = name;
                get.image = image;
                get.categoryname = categoryname;
                
                context.servicesubcategoriess.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public ServiceSubcategories getbyidCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.servicesubcategoriess.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string DeleteCategories(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.servicesubcategoriess.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
