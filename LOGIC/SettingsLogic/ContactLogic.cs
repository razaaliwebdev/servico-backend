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
    public class ContactLogic
    {

        private IContact _Contact = new DAL.Functions.ContactFunction();
        public async Task<Boolean> CreateNewUser(string id, string firstname, string lastname, string email, string phone, string subject, string desc)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Contact.Updatecontact(id, firstname, lastname, email, phone, subject, desc);
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
                    var result = await _Contact.Addcontact(firstname, lastname, email, phone, subject, desc);
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
        public async Task<List<Contacts>> GetAllContact()
        {
            List<Contacts> getlist = await _Contact.GetAllcontact();
            return getlist;
        }

        public string DeleteContacts(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Contact.Deletecontact(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public Contacts getbyidContacts(string id)
        {

            var get = _Contact.getbyidcontact(id);

            return get;


        }

    }
}
