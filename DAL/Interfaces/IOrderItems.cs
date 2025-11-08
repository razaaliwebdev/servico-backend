using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderItems
    {
        Task<OrderItems> AddOrderItems(OrderItems orderItems);
        Task<List<OrderItems>> GetAllOrderItems();

        string DeleteOrderItems(string id);
        Task<List<OrderItems>> getbyidOrderItems(string id);
  

    }
}
