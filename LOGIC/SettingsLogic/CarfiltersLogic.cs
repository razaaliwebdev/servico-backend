using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;

namespace LOGIC.SettingsLogic
{
    public class CarfiltersLogic
    {
        private ICarFilter _Categories = new DAL.Functions.CarfilterFunction();
        public async Task<Boolean> Add(string id, string year, string make, string model, string bodytype, string fueltype, string makeimage)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Categories.Update(id, year, make, model, bodytype, fueltype ,makeimage);
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
                    var result = await _Categories.Add(id, year, make, model, bodytype, fueltype, makeimage);
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

        public async Task<List<Carfilters>> GetAllCategories()
        {
            List<Carfilters> getlist = await _Categories.GetAll();
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
        public Carfilters getbyidCategoriess(string id)
        {

            var get = _Categories.getbyid(id);

            return get;


        }
    }

}
