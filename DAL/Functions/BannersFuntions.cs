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
    public class BannersFuntions : IBanners
    {
        public async Task<Banners> AddBanners(string bnum, string image, string value, string productid,string type)
        {
            Banners newUser = new Banners

            {
                bnum = bnum,
                image = image,
                value = value,
                productid=productid,
                type=type



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.bannerss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Banners>> GetAllBanners()
        {
            List<Banners> Banners = new List<Banners>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Banners = await context.bannerss.ToListAsync();

            }
            return Banners;
        }

        public async Task<Banners> UpdateBanners(string id, string bnum, string image, string value, string productid,string type)
        {
            Banners newUser = new Banners

            {
                banner_ID = Convert.ToInt32(id),
                bnum = bnum,
                image = image,
                value = value,
                productid = productid,
                type = type




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.bannerss.FirstOrDefault(x => x.banner_ID == Convert.ToInt64(id));
                get.bnum = bnum;
                get.value = value;
                get.type = type;
                get.productid = productid;
                get.image = image;
                context.bannerss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteBanners(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.bannerss.FirstOrDefault(x => x.banner_ID == Convert.ToInt64(id));
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
        public Banners getbyidBanners(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.bannerss.FirstOrDefault(x => x.banner_ID == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }

}
