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
    public class BookingFunction : IBooking
    {
        public async Task<Booking> Addbooking(string fullname, string phone, string email, string date, string time, string area, string city, string state, string code, string shopid)
        {

            Booking newUser = new Booking

            {
                fullname = fullname,
                phone = phone,
                email = email,
                date = date,
                time = time,
                area = area,
                city=city,
                state=state,
                code=code,
                shopid=shopid




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.bookingss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Booking>> GetAllbooking()
        {
            List<Booking> booking = new List<Booking>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                booking = await context.bookingss.OrderByDescending(s => s.id).ToListAsync();

            }
            return booking;
        }

        public async Task<Booking> Updatebooking(string id, string fullname, string phone, string email, string date, string time, string area, string city, string state, string code, string shopid)
        {
            Booking newUser = new Booking

            {
                fullname = fullname,
                phone = phone,
                email = email,
                date = date,
                time = time,
                area = area,
                city = city,
                state = state,
                code = code,
                shopid = shopid


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.bookingss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.fullname = fullname;
                get.phone = phone;
                get.email = email;
                get.date = date;
                get.time = time;
                get.area = area;
                get.city = city;
                get.state = state;
                get.code = code;
                get.shopid = shopid;
                context.bookingss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public Booking getbyidbooking(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.bookingss.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }

        public string Deletebooking(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.bookingss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
