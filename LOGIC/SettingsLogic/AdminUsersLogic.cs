using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class AdminUsersLogic
    {

        private IAdminUsers _Signup = new DAL.Functions.AdminUsersFunction();
        public async Task<Boolean> CreateNewUser(string id, string name, string type, string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Signup.UpdateSignup(id, name, type, password);
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
                    var result = await _Signup.AddSignup(name, type, password);
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
                    var result = await _Signup.UpdateSignup(name);
                    if (result.Signup_ID > 0)
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
        public async Task<List<AdminUsers>> GetAllSignup()
        {
            List<AdminUsers> getlist = await _Signup.GetAllSignup();
            return getlist;
        }

        public string DeleteSignups(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Signup.DeleteSignup(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public AdminUsers getbyidSignups(string id)
        {

            var get = _Signup.getbyidSignup(id);

            return get;


        }
        public AdminUsers Getlogin(AdminUsers obj)
        {

            var get = _Signup.GetLogin(obj);

            return get;


        }
    }

}
