using DAL.DataContext;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class Confirmation
    {
        public async Task<string> UpdateSignup(  string email)
        {
          
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var get = context.signups.FirstOrDefault(x => x.email == email);
             
           
                get.verification = "true";
                context.signups.Update(get);
              await context.SaveChangesAsync();
            }
            return "true";
           

        }
    }
}
