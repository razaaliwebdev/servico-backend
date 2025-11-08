using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class OrdersLogic
    {
        private IOrders _Orders = new DAL.Functions.OrderFunctions();
        public async Task<string> CreateNewOrder(Orders order)
        {
            try
            {
             /*   if (!string.IsNullOrEmpty(Orders_ID) && Convert.ToInt64(Orders_ID) > 0)
                {
                    var get = _Orders(name, Orders_ID);
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
                    var result = await _Orders.AddOrders(order);
                    if (result.order_ID > 0)
                    {
                        return result.order_ID.ToString();
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
 
        public async Task<List<Orders>> GetAllOrders()
        {
            List<Orders> getlist = await _Orders.GetAllOrders();
            return getlist;
        }

        public string DeleteOrderss(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Orders.DeleteOrders(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public Orders getbyidOrderss(string id)
        {

            var get = _Orders.getbyidOrders(id);

            return get;


        }
    }
}
