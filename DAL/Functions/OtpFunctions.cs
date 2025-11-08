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
    public class OtpFunctions :IOtp
    {
        public async Task<Otp> AddOtp(string email, string code)
        {
            Otp newUser = new Otp

            {
                email = email,
                code = code
        



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.Otps.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Otp>> GetAllOtp()
        {
            List<Otp> Otp = new List<Otp>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Otp = await context.Otps.ToListAsync();

            }
            return Otp;
        }

        public async Task<Otp> UpdateOtp(string email, string id, string code)
        {
            Otp newUser = new Otp

            {
                id = Convert.ToInt32(id),
                email = email,
                code = code



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.Otps.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.email = email;
                get.code = code;
              
                context.Otps.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string DeleteOtp(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.Otps.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
        public Otp getbyidOtp(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.Otps.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
