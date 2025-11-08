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
    public class BrandsFunction : IBrands
    {

        public async Task<Brands> AddBrands(string name,string desc, string image)
        {
            Brands newUser = new Brands

            {
                name = name,
                details=desc,
                Image=image



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.brandss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Brands>> GetAllBrands()
        {
            List<Brands> brands = new List<Brands>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                brands = await context.brandss.ToListAsync();

            }
            return brands;
        }

        public async Task<Brands> UpdateBrands(string name, string id, string desc, string image)
        {
            Brands newUser = new Brands

            {
                Brand_ID=Convert.ToInt32(id),
                name = name,
                details = desc,
                Image = image



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.brandss.FirstOrDefault(x => x.Brand_ID == Convert.ToInt64(id));
                get.name = name;
                get.details = desc;
                get.Image = image;
                context.brandss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteBrands(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.brandss.FirstOrDefault(x => x.Brand_ID == Convert.ToInt64(id));
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
        public Brands getbyidBrands(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.brandss.FirstOrDefault(x => x.Brand_ID == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
