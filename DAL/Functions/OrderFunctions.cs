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
    public class OrderFunctions:IOrders
    {
        public async Task<Orders> AddOrders(Orders orders)
        {
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.Orderss.AddAsync(orders);
                await context.SaveChangesAsync();
            }

            return orders;

        }



        public async Task<List<Orders>> GetAllOrders()
        {
            List<Orders> Orders = new List<Orders>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                Orders = await context.Orderss.OrderByDescending(s => s.order_ID).ToListAsync();

            }
            return Orders;
        }

     

        public Orders getbyidOrders(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.Orderss.FirstOrDefault(x => x.order_ID == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string DeleteOrders(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.Orderss.FirstOrDefault(x => x.order_ID == Convert.ToInt64(id));
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
