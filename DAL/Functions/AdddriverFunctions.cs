using DAL.DataContext;
using DAL.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Functions
{
    public class AdddriverFunctions : IDriver
    {

        public async Task<Driver> Add(string id, string name, string image, string opentime, string closetime, string expiry, string email, string password,string vid)
        {

            Driver newUser = new Driver

            {
                name = name,
                image = image,

                opentime = opentime,
                closetime = closetime,
                expiry = expiry,
                email = email,
                password = password,
                vid = vid






            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.drivers.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Driver>> GetAll()
        {
            List<Driver> Signup = new List<Driver>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Signup = await context.drivers.OrderByDescending(s => s.id).ToListAsync();

            }
            return Signup;
        }

        public async Task<Driver> Update(string id, string name, string image, string opentime, string closetime, string expiry, string email, string password,string vid)
        {
            Driver newUser = new Driver

            {
                name = name,
                image = image,

                opentime = opentime,
                closetime = closetime,
                expiry = expiry,
                email = email,
                password = password, vid = vid






            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.drivers.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.name = name;
                get.image = image;
                get.opentime = opentime;
                get.closetime = closetime;

                get.expiry = expiry;
                get.email = email;
                get.password = password;
                context.drivers.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public Driver getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.drivers.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }

        public string Delete(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.drivers.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
