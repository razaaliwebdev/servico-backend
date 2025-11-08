using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace LOGIC.SettingsLogic
{
    public class TyreBrandImagesLogic
    {
        private ITyreBrandImages _Brands = new DAL.Functions.TyreBrandImageFunction();
        public async Task<Boolean> CreateNewBrands(string name, string id, string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Brands.UpdateBrands(name, id, image);
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
                    var result = await _Brands.AddBrands(name,image);
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

        public async Task<List<Tyrebrandimage>> GetAllBrands()
        {
            List<Tyrebrandimage> getlist = await _Brands.GetAllBrands();
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
        public Tyrebrandimage getbyidBrands(string id)
        {

            var get = _Brands.getbyidBrands(id);

            return get;


        }
    }
}
