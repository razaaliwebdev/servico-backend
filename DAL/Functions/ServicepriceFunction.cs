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
    public class ServicepriceFunction : IServicePrice
    {
        public async Task<ServicePrice> Add(string id, string staffless, string staffmore, string categoryname, string subcategoryname, string servicename, string servicecompanyname, string servicecompanyid, string price)
        {
            ServicePrice newUser = new ServicePrice

            {
                staffless = staffless,
                staffmore = staffmore,
                categoryname = categoryname,
                subcategoryname=subcategoryname,
                servicename = servicename,
                servicecompanyname = servicecompanyname,
                servicecompanyid = servicecompanyid,
                price = price



            };

            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.seriviceprices.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<ServicePrice>> GetAll()
        {
            List<ServicePrice> categories = new List<ServicePrice>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.seriviceprices.ToListAsync();

            }
            return categories;
        }

        public async Task<ServicePrice> Update(string id, string staffless, string staffmore, string categoryname, string subcategoryname, string servicename, string servicecompanyname, string servicecompanyid, string price)
        {
            ServicePrice newUser = new ServicePrice

            {

                staffless = staffless,
                staffmore = staffmore,
                categoryname = categoryname,
                subcategoryname = subcategoryname,
                servicename = servicename,
                servicecompanyname = servicecompanyname,
                servicecompanyid = servicecompanyid,
                price = price



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.seriviceprices.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get = newUser;
                context.seriviceprices.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public ServicePrice getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.seriviceprices.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string Delete(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.seriviceprices.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
