using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LOGIC.SettingsLogic
{
    public class ServicePriceLogic
    {
        private IServicePrice _Services = new DAL.Functions.ServicepriceFunction();
     

        public async Task<Boolean> Add(string id, string staffless, string staffmore, string categoryname, string subcategoryname, string servicename, string servicecompanyname, string servicecompanyid, string price)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Services.Update(id, staffless, staffmore, categoryname, subcategoryname, servicename, servicecompanyname, servicecompanyid, price);
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
                    var result = await _Services.Add(id, staffless, staffmore, categoryname, subcategoryname, servicename, servicecompanyname, servicecompanyid, price);
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

        public async Task<List<ServicePrice>> GetAllCategories()
    {
        List<ServicePrice> getlist = await  _Services.GetAll();
        return getlist;
    }

    public string DeleteCategoriess(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var get = _Services.Delete(id);

            return get;
        }
        else
        {
            return "";
        }

    }
    public ServicePrice getbyidCategoriess(string id)
    {

        var get = _Services.getbyid(id);

        return get;


    }
}

}
