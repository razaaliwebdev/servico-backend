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
    public class OrderItemFunctions:IOrderItems
    {

        public async Task<OrderItems> AddOrderItems(OrderItems OrderItems)
        {
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                await context.OrderItemss.AddAsync(OrderItems);
                await context.SaveChangesAsync();
            }

            return OrderItems;

        }



        public async Task<List<OrderItems>> GetAllOrderItems()
        {
            List<OrderItems> OrderItems = new List<OrderItems>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                OrderItems = await context.OrderItemss.ToListAsync();

            }
            return OrderItems;
        }



        public async Task<List<OrderItems>> getbyidOrderItems(string id)
        {


            List<OrderItems> OrderItems = new List<OrderItems>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                OrderItems = await context.OrderItemss.Where(x=>x.order_id.ToString() == id).ToListAsync();

            }
            return OrderItems;
        }
        public string DeleteOrderItems(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.OrderItemss.FirstOrDefault(x => x.orderItems_ID == Convert.ToInt64(id));
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
