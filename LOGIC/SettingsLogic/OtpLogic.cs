using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class OtpLogic
    {
        private IOtp _Otp = new DAL.Functions.OtpFunctions();
        public async Task<Boolean> CreateNewOtp(string email, string id, string code)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Otp.UpdateOtp(email, id, code);
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
                    var result = await _Otp.AddOtp(email,code);
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

        public async Task<List<Otp>> GetAllOtp()
        {
            List<Otp> getlist = await _Otp.GetAllOtp();
            return getlist;
        }
        public string DeleteOtp(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Otp.DeleteOtp(id);

                return "true";
            }
            else
            {
                return "false";
            }

        }
        public Otp getbyidOtp(string id)
        {

            var get = _Otp.getbyidOtp(id);

            return get;


        }
    }
}
