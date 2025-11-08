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
    public class AddVehicleFunction : IVehicle
    {

        public async Task<Vehicle> Add(string id,string category, string make, string model,string year,string numberplate)
        {

            Vehicle newUser = new Vehicle

            {
                category = category,
                make = make,

                model = model,
                year = year,
                numberplate = numberplate





            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.vehicles.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Vehicle>> GetAll()
        {
            List<Vehicle> Signup = new List<Vehicle>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Signup = await context.vehicles.OrderByDescending(s => s.id).ToListAsync();

            }
            return Signup;
        }

        public async Task<Vehicle> Update(string id, string category, string make, string model, string year, string numberplate)
        {
            Vehicle newUser = new Vehicle

            {
                category = category,
                make = make,

                model = model,
                year = year,
                numberplate = numberplate


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.vehicles.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.category = category;
                get.make = make;
                get.model = model;
                get.year = year;

                get.numberplate= numberplate;
                context.vehicles.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public Vehicle getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.vehicles.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
    
        public string Delete(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.vehicles.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
