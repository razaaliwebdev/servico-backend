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
    public class MetaMainFunctions : IMainMeta
    {

        public async Task<metamain> Addmetamains(string bnum, string metatitle, string metadesc, string metakeyword)
        {
            metamain newUser = new metamain

            {
                bnum = bnum,
                metatitle = metatitle,
                metadesc = metadesc,
                metakeyword = metakeyword,
             



            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.metamains.AddAsync(newUser);
                await context.SaveChangesAsync();
            }

            return newUser;

        }



        public async Task<List<metamain>> GetAllmetamains()
        {
            List<metamain> metamains = new List<metamain>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                metamains = await context.metamains.ToListAsync();

            }
            return metamains;
        }

        public async Task<metamain> Updatemetamains(string id, string bnum, string metatitle, string metdesc, string metakeyword)
        {
            metamain newUser = new metamain

            {
                id = Convert.ToInt32(id),
                bnum = bnum,
                metatitle = metatitle,
                metadesc = metdesc,
                metakeyword = metakeyword,
             




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.metamains.FirstOrDefault(x => x.id == Convert.ToInt64(id));
                get.bnum = bnum;
                get.metatitle = metatitle;
                get.metadesc = metdesc;
                get.metakeyword = metakeyword;
              
                context.metamains.Update(get);
                await context.SaveChangesAsync();
            }

            return newUser;

        }

        public string Deletemetamains(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.metamains.FirstOrDefault(x => x.id == Convert.ToInt64(id));
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
        public metamain getbyidmetamains(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.metamains.FirstOrDefault(x => x.id == Convert.ToInt64(id));

                return getbyID;


            }


        }
    }
}
