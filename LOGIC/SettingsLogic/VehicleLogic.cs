using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class VehicleLogic
    {

        private IVehicle _Categories = new DAL.Functions.AddVehicleFunction();
        public async Task<Boolean> Add(string id, string category, string make, string model, string year, string numberplate)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Categories.Update(id, category, make, model, year, numberplate);
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
                    var result = await _Categories.Add(id, category, make, model, year, numberplate);
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

        public async Task<List<Vehicle>> GetAll()
        {
            List<Vehicle> getlist = await _Categories.GetAll();
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
        public Vehicle getbyid(string id)
        {

            var get = _Categories.getbyid(id);

            return get;


        }
    }

}
