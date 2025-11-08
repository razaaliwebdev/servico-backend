using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class MetaMainLogic
    {
        private IMainMeta _metamains = new DAL.Functions.MetaMainFunctions();
        public async Task<Boolean> CreateNewmetamains(string id, string bnum, string metatitle, string metadesc, string metakeyword)
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _metamains.Updatemetamains(id, bnum, metatitle, metadesc, metakeyword);
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
                    var result = await _metamains.Addmetamains(bnum, metatitle, metadesc, metakeyword);
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

        public async Task<List<metamain>> GetAllmetamains()
        {
            List<metamain> getlist = await _metamains.GetAllmetamains();
            return getlist;
        }
        public string Deletemetamains(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _metamains.Deletemetamains(id);

                return "true";
            }
            else
            {
                return "false";
            }

        }
        public metamain getbyidmetamains(string id)
        {

            var get = _metamains.getbyidmetamains(id);

            return get;


        }
    }
}
