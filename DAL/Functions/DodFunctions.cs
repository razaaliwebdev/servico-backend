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
    public class DodFunctions : IDOD
    {
        public async Task<DOD> AddBanners(string bnum, string image, string value, string productid, string type,string details, string dealcounter,string price)
        {
            DOD newUser = new DOD

            {
                bnum = bnum,
                image = image,
                value = value,
                productid = productid,
                type = type,
                dealcounter=dealcounter,
                details=details,
                price=price


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.dods.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<DOD>> GetAllBanners()
        {
            List<DOD> Banners = new List<DOD>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Banners = await context.dods.ToListAsync();

            }
            return Banners;
        }

        public async Task<DOD> UpdateBanners(string id, string bnum, string image, string value, string productid, string type, string details, string dealcounter,string price)
        {
            DOD newUser = new DOD

            {
                banner_ID = Convert.ToInt32(id),
                bnum = bnum,
                image = image,
                value = value,
                productid = productid,
                type = type,
                dealcounter = dealcounter,
                details = details,
                price =price



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.dods.FirstOrDefault(x => x.banner_ID == Convert.ToInt64(id));
                get.bnum = bnum;
                get.value = value;
                get.type = type;
                get.productid = productid;
                get.image = image;
                get.price = price;
                context.dods.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteBanners(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.dods.FirstOrDefault(x => x.banner_ID == Convert.ToInt64(id));
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
        public DOD getbyidBanners(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.dods.FirstOrDefault(x => x.banner_ID == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
