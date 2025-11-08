using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class OrderItemsLogic
    {
        private IOrderItems _OrderItems = new DAL.Functions.OrderItemFunctions();
        public async Task<string> CreateNewOrder(OrderItems order)
        {
            try
            {
                /*   if (!string.IsNullOrEmpty(OrderItems_ID) && Convert.ToInt64(OrderItems_ID) > 0)
                   {
                       var get = _OrderItems(name, OrderItems_ID);
                       if (get.Id > 0)
                       {
                           return true;
                       }
                       else
                       {
                           return false;
                       }

                   }*/
                //    else
                //      {
                var result = await _OrderItems.AddOrderItems(order);
                if (result.orderItems_ID > 0)
                {
                    return "true";
                }
                else
                {
                    return "false";
                }

                // }

            }
            catch (Exception error)
            {
                return "false";
            }
        }

        public async Task<List<OrderItems>> GetAllOrderItems()
        {
            List<OrderItems> getlist = await _OrderItems.GetAllOrderItems();
            return getlist;
        }

        public async Task<List<OrderItems>> DeleteOrderItemss(string id)
        {
            List<OrderItems> getlist = await _OrderItems.getbyidOrderItems(id);
            return getlist;

        }
        public async Task<List<OrderItems>> getbyidOrderItemss(string id)
        {

            var get = await _OrderItems.getbyidOrderItems(id);

            return get;


        }
    }
}
