using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class SubcategoryLogic
    {
        private ISubCategories _Categories = new DAL.Functions.SubCategoriesFunction();
        public async Task<Boolean> CreateNewCategory(string name,string id, string Categories_ID,string categoryname)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Categories.UpdateCategories(name,id, Categories_ID,categoryname);
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
                    var result = await _Categories.AddCategories(name, id, Categories_ID, categoryname);
                    if (result.Subid > 0)
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

        public async Task<List<Subcategories>> GetAllCategories()
        {
            List<Subcategories> getlist = await _Categories.GetAllCategories();
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
        public  Subcategories getbyidCategoriess(string id)
        {

            var get = _Categories.getbyidCategories(id);

            return get;


        }
    }

}
