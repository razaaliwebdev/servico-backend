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
    public class AttributeFunction :IAttributes
    {
        public async Task<Attributes> AddAttributes(string name)
        {
            Attributes newUser = new Attributes

            {
                name = name,



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.attributes.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Attributes>> GetAllAttributes()
        {
            List<Attributes> attributes = new List<Attributes>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                attributes = await context.attributes.ToListAsync();

            }
            return attributes;
        }

        public async Task<Attributes> UpdateAttributes(string name,string id)
        {
            Attributes newUser = new Attributes

            {
                name = name
            


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.attributes.FirstOrDefault(x => x.AttributeID == Convert.ToInt64(id));
                get.name = name;
                context.attributes.Update(get);
               
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteAttributes(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.attributes.FirstOrDefault(x => x.AttributeID == Convert.ToInt64(id));
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
        public Attributes getbyidAttributes(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.attributes.FirstOrDefault(x => x.AttributeID == Convert.ToInt64(id));

                return getbyID;


            }
        }
    }
}
