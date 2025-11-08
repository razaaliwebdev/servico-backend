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
    public class ContactFunction :IContact
    {
        public async Task<Contacts> Addcontact(string firstname, string lastname, string email, string phone, string subject,string desc)
        {

            Contacts newUser = new Contacts

            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                phone = phone,
                subject = subject,
                desc=desc




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.contactss.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<Contacts>> GetAllcontact()
        {
            List<Contacts> contact = new List<Contacts>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                contact = await context.contactss.OrderByDescending(s => s.id).ToListAsync();

            }
            return contact;
        }

        public async Task<Contacts> Updatecontact(string id, string firstname, string lastname, string email, string phone, string subject, string desc)
        {
            Contacts newUser = new Contacts

            {
                firstname = firstname,
                lastname = lastname,
                email = email,
                phone = phone,
                subject = subject,
                desc = desc


            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.contactss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.firstname = firstname;
                get.lastname = lastname;
                get.email = email;
                get.phone = phone;
                get.subject = subject;
                get.desc = desc;
                context.contactss.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }


        public Contacts getbyidcontact(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.contactss.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }
        }

        public string Deletecontact(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.contactss.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
