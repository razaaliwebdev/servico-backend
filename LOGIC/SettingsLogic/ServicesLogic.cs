using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace LOGIC.SettingsLogic
{
    public class ServicesLogic
    {
        private IServices _Services = new DAL.Functions.ServicesFunction();
     
        public async Task<Boolean> AddServices(string id,string title, string type, string location, string emirates, string opentime, string closetime, string img, string expiry, string adminid, string Categories_ID, string categoryname, string SubCategoryid , string subcategoryname,string username,string password, string phone)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Services.UpdateServices( id,  title,  type,  location,  emirates,  opentime, closetime,  img,  expiry, adminid,  Categories_ID,  categoryname,  SubCategoryid,  subcategoryname,  username,  password,phone);
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
                    var result = await _Services.AddServices(id, title, type, location, emirates, opentime, closetime, img, expiry, adminid, Categories_ID, categoryname, SubCategoryid, subcategoryname, username, password, phone);
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

        public async Task<List<Services>> GetAllServices()
        {
            List<Services> getlist = await _Services.GetAllServices();
            return getlist;
        }
        public string DeleteServices(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Services.DeleteServices(id);

                return "true";
            }
            else
            {
                return "false";
            }

        }
        public Services getbyidServices(string id)
        {

            var get = _Services.getbyidServices(id);

            return get;


        }

       

    }
}
