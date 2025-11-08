using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class SignupLogic
    {
        private ISignup _Signup = new DAL.Functions.SignupFunctions();
        public async Task<Boolean> CreateNewUser(string id,string firstname, string lastname, string email, string phone, string password,string type, string document1, string document2, string extra, string verfication)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Signup.UpdateSignup(id,firstname,lastname,email,phone,password,type,  document1,  document2,  extra, verfication);
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
                    var result = await _Signup.AddSignup(firstname, lastname, email, phone, password, type, document1, document2, extra, verfication);
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
        public async Task<List<Signup>> GetAllSignup()
        {
            List<Signup> getlist = await _Signup.GetAllSignup();
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
        public Signup getbyidSignups(string id)
        {

            var get = _Signup.getbyidSignup(id);

            return get;


        }
        public Signup Getlogin(Signup obj)
        {

            var get = _Signup.GetLogin(obj);

            return get;


        }
        public string ForgotPassword(Signup obj)
        {

            var get = _Signup.ForgotPassword(obj);

            return get;


        }
    }

}
