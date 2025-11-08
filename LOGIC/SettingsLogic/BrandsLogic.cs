using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class BrandsLogic
    {
        private IBrands _Brands = new DAL.Functions.BrandsFunction();
        public async Task<Boolean> CreateNewBrands(string name,string id,string desc,string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Brands.UpdateBrands(name, id,desc,image);
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
                    var result = await _Brands.AddBrands(name,desc,image);
                    if (result.Brand_ID > 0)
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

        public async Task<List<Brands>> GetAllBrands()
        {
            List<Brands> getlist = await _Brands.GetAllBrands();
            return getlist;
        }
        public string DeleteBrands(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Brands.DeleteBrands(id);

                return "true";
            }
            else
            {
                return "false";
            }

        }
        public Brands getbyidBrands(string id)
        {

            var get = _Brands.getbyidBrands(id);

            return get;


        }
    }
}
