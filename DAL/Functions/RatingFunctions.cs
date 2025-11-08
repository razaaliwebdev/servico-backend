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
    public class RatingFunctions : IRating
    {
        public async Task<rating> Addratings(rating rating)
        {
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.ratings.AddAsync(rating);
                await context.SaveChangesAsync();
            }

            return rating;

        }



        public async Task<List<rating>> GetAllratings()
        {
            List<rating> rating = new List<rating>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                rating = await context.ratings.OrderByDescending(s => s.id).ToListAsync();

            }
            return rating;
        }



        public rating getbyidratings(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.ratings.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string Deleteratings(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.ratings.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
