using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBooking
    {
        Task<Booking> Addbooking(string fullname, string phone, string email, string date, string time, string area, string city, string state, string code, string shopid);
        Task<List<Booking>> GetAllbooking();

        string Deletebooking(string id);
        Booking getbyidbooking(string id);
        Task<Booking> Updatebooking(string id, string fullname, string phone, string email, string date, string time, string area, string city, string state, string code, string shopid);
    }
}
