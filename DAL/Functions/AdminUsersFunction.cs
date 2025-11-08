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
    public class AdminUsersFunction : IAdminUsers
    {

        public async Task<AdminUsers> AddSignup(string name, string type,  string password)
        {

            AdminUsers newUser = new AdminUsers

            {
                name = name,
                type = type,
             
                password = password




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.adminuserss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<AdminUsers>> GetAllSignup()
        {
            List<AdminUsers> Signup = new List<AdminUsers>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Signup = await context.adminuserss.OrderByDescending(s => s.id).ToListAsync();

            }
            return Signup;
        }

        public async Task<AdminUsers> UpdateSignup(string id, string name, string type, string password)
        {
            AdminUsers newUser = new AdminUsers

            {
                name = name,
                type = type,
               
                password = password


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.adminuserss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.name = name;
                get.type = type;
         
                get.password = password;
                context.adminuserss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public AdminUsers getbyidSignup(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.adminuserss.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public AdminUsers GetLogin(AdminUsers obj)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.adminuserss.FirstOrDefault(x => x.name == obj.name && x.password == obj.password);

                return getbyID;


            }
        }
        public string DeleteSignup(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.adminuserss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
