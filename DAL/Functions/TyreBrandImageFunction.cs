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
    public class TyreBrandImageFunction : ITyreBrandImages
    {

        public async Task<Tyrebrandimage> AddBrands(string name, string image)
        {
            Tyrebrandimage newUser = new Tyrebrandimage

            {
                name = name,
             
                Image = image



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.tyrebrandimages.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Tyrebrandimage>> GetAllBrands()
        {
            List<Tyrebrandimage> brands = new List<Tyrebrandimage>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                brands = await context.tyrebrandimages.ToListAsync();

            }
            return brands;
        }

        public async Task<Tyrebrandimage> UpdateBrands(string name, string id, string image)
        {
            Tyrebrandimage newUser = new Tyrebrandimage

            {
                Brand_ID = Convert.ToInt32(id),
                name = name,
           
                Image = image



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.tyrebrandimages.FirstOrDefault(x => x.Brand_ID == Convert.ToInt64(id));
                get.name = name;
             
                get.Image = image;
                context.tyrebrandimages.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteBrands(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.tyrebrandimages.FirstOrDefault(x => x.Brand_ID == Convert.ToInt64(id));
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
        public Tyrebrandimage getbyidBrands(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.tyrebrandimages.FirstOrDefault(x => x.Brand_ID == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
