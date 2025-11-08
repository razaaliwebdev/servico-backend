using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Functions
{
    public class CarfilterFunction : ICarFilter
    {
        public async Task<Carfilters> Add(string id, string year, string make, string model, string bodytype, string fueltype,string makeimage)
        {
            Carfilters newUser = new Carfilters

            {
             year = year,
             make = make,
             model = model,
             bodytype = bodytype,
             fueltype = fueltype,
             makeimage = makeimage





            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.carfilterss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Carfilters>> GetAll()
        {
            List<Carfilters> categories = new List<Carfilters>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                categories = await context.carfilterss.ToListAsync();

            }
            return categories;
        }

        public async Task<Carfilters> Update(string id, string year, string make, string model, string bodytype, string fueltype, string makeimage)
        {
            Carfilters newUser = new Carfilters

            {

                year = year,
                make = make,
                model = model,
                bodytype = bodytype,
                fueltype = fueltype,
                makeimage = makeimage





            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.carfilterss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.year = year;
                get.make = make;
                get.model = model;
                get.bodytype = bodytype;
                get.fueltype = fueltype;
                get.makeimage = makeimage;
               
                context.carfilterss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public Carfilters getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.carfilterss.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string Delete(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.carfilterss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
