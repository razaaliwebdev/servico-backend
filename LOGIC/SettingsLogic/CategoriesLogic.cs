using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class CategoriesLogic
    {
        private ICategories _Categories = new DAL.Functions.CategoriesFunction();
        public async Task<Boolean> CreateNewCategory(string name,string Categories_ID,string slug)
        {
            try
            {
                if (!string.IsNullOrEmpty(Categories_ID) && Convert.ToInt64(Categories_ID) > 0 )
                {
                    var get = _Categories.UpdateCategories(name, Categories_ID,slug);
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
                    var result = await _Categories.AddCategories(name,slug);
                    if (result.Categories_ID > 0)
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
                var result = await _Categories.UpdateCategories(name);
                if (result.Categories_ID > 0)
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
        public async Task<List<Categories>> GetAllCategories()
        {
            List<Categories> getlist = await _Categories.GetAllCategories();
            return getlist;
        }

        public  string DeleteCategoriess(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get =  _Categories.DeleteCategories(id);
                
                return get;
            }
            else
            {
                return "";
            }
         
        }
        public Categories getbyidCategoriess(string id)
        {
          
                var get = _Categories.getbyidCategories(id);

                return get;

            
        }
    }
}
