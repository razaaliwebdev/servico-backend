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
    public class tyrebrandpriceFunction: Ityerbrandprice
    {
        public async Task<tyrebrandprice> Add(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel,string price)
        {
            tyrebrandprice newUser = new tyrebrandprice

            {
                countrybrand = countrybrand,
                countrymade = countrymade,
                width = width,
                height = height,
                rimsize = rimsize,
                tyremodel = tyremodel,
                price=price
                




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.tyrebrandprices.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<tyrebrandprice>> GetAll()
        {
            List<tyrebrandprice> categories = new List<tyrebrandprice>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.tyrebrandprices.ToListAsync();

            }
            return categories;
        }

        public async Task<tyrebrandprice> Update(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel,string price)
        {
            tyrebrandprice newUser = new tyrebrandprice

            {

                countrybrand = countrybrand,
                countrymade = countrymade,
                width = width,
                height = height,
                rimsize = rimsize,
                tyremodel = tyremodel,
                price=price





            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.tyrebrandprices.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.countrybrand = countrybrand;
                get.countrymade = countrymade;
                get.width = width;
                get.height = height;
                get.rimsize = rimsize;
                get.tyremodel = tyremodel;
                context.tyrebrandprices.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public tyrebrandprice getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.tyrebrandprices.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string Delete(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.tyrebrandprices.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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