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
    public class tyrebrandFunction : Ityrebrand
    {
        public async Task<tyrebrand> Add(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel)
        {
            tyrebrand newUser = new tyrebrand

            {
                countrybrand = countrybrand,
                countrymade = countrymade,
                width = width,
                height = height,
                rimsize = rimsize,
                tyremodel = tyremodel,
               



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.tyrebrands.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<tyrebrand>> GetAll()
        {
            List<tyrebrand> categories = new List<tyrebrand>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.tyrebrands.ToListAsync();

            }
            return categories;
        }

        public async Task<tyrebrand> Update(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel)
        {
            tyrebrand newUser = new tyrebrand

            {

                countrybrand = countrybrand,
                countrymade = countrymade,
                width = width,
                height = height,
                rimsize = rimsize,
                tyremodel = tyremodel,





            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.tyrebrands.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.countrybrand = countrybrand;
                get.countrymade = countrymade;
                get.width = width;
                get.height = height;
                get.rimsize = rimsize;
                get.tyremodel = tyremodel;
                context.tyrebrands.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public tyrebrand getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.tyrebrands.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string Delete(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.tyrebrands.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
