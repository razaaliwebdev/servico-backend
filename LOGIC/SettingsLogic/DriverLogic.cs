using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class DriverLogic
    {
      private IDriver _Categories = new DAL.Functions.AdddriverFunctions();
    public async Task<Boolean> Add(string id, string name, string image, string opentime, string closetime, string expiry, string email, string password,string vid)
        {
        try
        {
            if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
            {
                var get = _Categories.Update(id, name, image, opentime, closetime, expiry,email,password,vid);
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
                var result = await _Categories.Add(id, name, image, opentime, closetime, expiry, email, password,vid);
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

    public async Task<List<Driver>> GetAll()
    {
        List<Driver> getlist = await _Categories.GetAll();
        return getlist;
    }

    public string Delete(string id)
    {
        if (!string.IsNullOrEmpty(id))
        {
            var get = _Categories.Delete(id);

            return get;
        }
        else
        {
            return "";
        }

    }
    public Driver getbyid(string id)
    {

        var get = _Categories.getbyid(id);

        return get;


    }
}

}
