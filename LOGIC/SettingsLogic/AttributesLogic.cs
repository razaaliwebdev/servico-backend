using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class AttributesLogic
    {
        private IAttributes _Attributes = new DAL.Functions.AttributeFunction();
        public async Task<Boolean> CreateNewAttributes(string name,string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Attributes.UpdateAttributes(name, id);
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
                    var result = await _Attributes.AddAttributes(name);
                    if (result.AttributeID > 0)
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

 
        public async Task<List<Attributes>> GetAllAttributes()
        {
            List<Attributes> getlist = await _Attributes.GetAllAttributes();
            return getlist;
        }
        public string DeleteAttributes(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Attributes.DeleteAttributes(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public Attributes getbyidAttributes(string id)
        {

            var get = _Attributes.getbyidAttributes(id);

            return get;


        }
    }
}
