using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class ServiceSubCategoriesLogic
    {
        private IServiceSubcategories _Categories = new DAL.Functions.ServiceSubCategoriesFunction();
        public async Task<Boolean> CreateNewCategory(string name, string id, string Categories_ID, string categoryname,string price,string image,string adminid)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Categories.UpdateCategories(name, id, Categories_ID, categoryname,price,image,adminid);
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
                    var result = await _Categories.AddCategories(name, id, Categories_ID, categoryname,price,image,adminid);
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

        public async Task<List<ServiceSubcategories>> GetAllCategories()
        {
            List<ServiceSubcategories> getlist = await _Categories.GetAllCategories();
            return getlist;
        }

        public string DeleteCategoriess(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Categories.DeleteCategories(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public ServiceSubcategories getbyidCategoriess(string id)
        {

            var get = _Categories.getbyidCategories(id);

            return get;


        }
    }

}
