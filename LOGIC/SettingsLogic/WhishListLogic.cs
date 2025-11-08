using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class WhishListLogic
    {
        private IWhisList  _Categories = new DAL.Functions.WishListFunction();
        public async Task<Boolean> CreateNew(string id, string productid,string userid)
        {
            try
            {
             
                    var result = await _Categories.Create(id,productid,userid);
                    if (result.whishid > 0)
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
        }

        public async Task<List<WhishList>> GetAll()
        {
            List<WhishList> getlist = await _Categories.GetAll();
            return getlist;
        }

        public string Deletewhishlist(string id,string userid)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Categories.Delete(id,userid);

                return get;
            }
            else
            {
                return "";
            }

        }
        public WhishList getbyid(string id)
        {

            var get = _Categories.getbyid(id);

            return get;


        }
    }
}
