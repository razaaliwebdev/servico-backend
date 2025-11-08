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
    public class ServicesFunction : IServices
   
    {

        public async Task<Services> AddServices(string id, string title, string type, string location, string emirates, string opentime, string closetime, string img, string expiry, string adminid, string Categories_ID, string categoryname, string SubCategoryid, string subcategoryname, string username, string password, string phone)
        {
            Services newUser = new Services

            {
                id = Convert.ToInt32(id),
                img = img,
                title = title,
                type = type,
                location = location,
                emirates = emirates,
                opentime=opentime,
                closetime=closetime,
                expiry=expiry,
                admin=adminid,
                catid= Categories_ID,
                subid= SubCategoryid,
                subname=subcategoryname,
                catname=categoryname,
                username=username,
                password=password,
                phone=phone




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.servicess.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Services>> GetAllServices()
        {
            List<Services> Services = new List<Services>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Services = await context.servicess.ToListAsync();

            }
            return Services;
        }

        public async Task<Services> UpdateServices(string id, string title, string type, string location, string emirates, string opentime, string closetime, string img, string expiry, string adminid, string Categories_ID, string categoryname, string SubCategoryid, string subcategoryname, string username, string password, string phone)
        {
            Services newUser = new Services

            {
                id = Convert.ToInt32(id),
                img = img,
                title = title,
                type = type,
                location = location,
                emirates = emirates,
                opentime = opentime,
                closetime = closetime,
                expiry = expiry,
                admin =adminid,
                catid = Categories_ID,
                subid = SubCategoryid,
                subname = subcategoryname,
                catname = categoryname,
                username = username,
                password = password,
                phone = phone

            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.servicess.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.title = title;
                get.img = img;
                get.title = title;
                get.type = type;
                get.location = location;
                get.emirates = emirates;
                get.opentime = opentime;
                get.closetime = closetime;
                get.expiry = expiry;
                get.admin = adminid;
                get.catid = Categories_ID;
                get.subid = SubCategoryid;
                get.catname = categoryname;
                get.subname = subcategoryname;
                get.username = username;
                get.password = password;
                get.phone = phone;
                


                context.servicess.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteServices(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.servicess.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
        public Services getbyidServices(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.servicess.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
