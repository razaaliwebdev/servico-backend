using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrders
    {
        Task<Orders> AddOrders(Orders order);
        Task<List<Orders>> GetAllOrders();

        string DeleteOrders(string id);
        Orders getbyidOrders(string id);
     
    }
}
