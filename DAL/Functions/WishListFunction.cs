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
    public class WishListFunction: IWhisList
    {
        public async Task<WhishList> Create(string id, string productid,string userid)
        {
            WhishList newUser = new WhishList
            {
                whishid = Convert.ToInt16(id),
                product_id = Convert.ToInt16(productid),
                id = Convert.ToInt16(userid)
             
            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.whish.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<WhishList>> GetAll()
        {
            List<WhishList> Blogs = new List<WhishList>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Blogs = await context.whish.ToListAsync();

            }
            return Blogs;
        }

  

        public string Delete(string id,string userid)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.whish.FirstOrDefault(x => x.product_id == Convert.ToInt64(id) &&  x.id == Convert.ToInt64(userid));
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
        public WhishList getbyid(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.whish.FirstOrDefault(x => x.whishid == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
