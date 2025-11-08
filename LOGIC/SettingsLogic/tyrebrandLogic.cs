using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class tyrebrandLogic
    {
        private Ityrebrand _Categories = new DAL.Functions.tyrebrandFunction();
        public async Task<Boolean> Add(string id, string countrybrand, string countrymade, string width, string height, string rimsize, string tyremodel)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Categories.Update( id,  countrybrand,  countrymade,  width,  height,  rimsize,  tyremodel);
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
                    var result = await _Categories.Add(id, countrybrand, countrymade, width, height, rimsize, tyremodel);
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

        public async Task<List<tyrebrand>> GetAllCategories()
        {
            List<tyrebrand> getlist = await _Categories.GetAll();
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
        public tyrebrand getbyidCategoriess(string id)
        {

            var get = _Categories.getbyid(id);

            return get;


        }
    }

}
