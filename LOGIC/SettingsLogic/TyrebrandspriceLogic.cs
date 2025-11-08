using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class TyrebrandspriceLogic { 


     private Ityerbrandprice _Categories = new DAL.Functions.tyrebrandpriceFunction();
    public async Task<Boolean> Add(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel,string price)
    {
        try
        {
            if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
            {
                var get = _Categories.Update(id, countrybrand, countrymade, width, height, rimsize, tyremodel,price);
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
                var result = await _Categories.Add(id, countrybrand, countrymade, width, height, rimsize, tyremodel,price);
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

    public async Task<List<tyrebrandprice>> GetAllCategories()
    {
        List<tyrebrandprice> getlist = await _Categories.GetAll();
        return getlist;
    }

    public string DeleteCategoriess(string id)
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
    public tyrebrandprice getbyidCategoriess(string id)
    {

        var get = _Categories.getbyid(id);

        return get;


    }
}

}
