using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModels;
using DAL.Entities;

namespace LOGIC.SettingsLogic
{
    public class BookingLogic
    {
        private IBooking _Contact = new DAL.Functions.BookingFunction();
        public async Task<Boolean> CreateNewUser(string id, string fullname, string phone, string email, string date, string time, string area, string city, string state, string code, string shopid)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Contact.Updatebooking(id, fullname,  phone,  email,  date,  time,  area,  city,  state,  code,  shopid);
                    if (get.Id > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    var result = await _Contact.Addbooking(fullname, phone, email, date, time, area, city, state, code, shopid);
                    if (result.id > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception error)
            {
                return false;
            }
        }
        /*    public async Task<Boolean> UpdateCategory(string name)
            {
                try
                {
                    var result = await _Contact.UpdateContact(name);
                    if (result.Contact_ID > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception error)
                {
                    return false;
                }
            }  */
        public async Task<List<Booking>> GetAllbooking()
        {
            List<Booking> getlist = await _Contact.GetAllbooking();
            return getlist;
        }

        public string DeleteBookings(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Contact.Deletebooking(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public Booking getbyidBookings(string id)
        {

            var get = _Contact.getbyidbooking(id);

            return get;


        }

    }
}

