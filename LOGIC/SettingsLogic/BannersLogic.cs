using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.SettingsLogic
{
    public class BannersLogic
    {
        private IBanners _Banners = new DAL.Functions.BannersFuntions();
        public async Task<Boolean> CreateNewBanners(string id, string bnum, string image, string value, string productid,string type )
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && Convert.ToInt64(id) > 0)
                {
                    var get = _Banners.UpdateBanners(id, bnum, image,value,productid,type);
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
                    var result = await _Banners.AddBanners(bnum, image,value,productid,type);
                    if (result.banner_ID > 0)
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

        public async Task<List<Banners>> GetAllBanners()
        {
            List<Banners> getlist = await _Banners.GetAllBanners();
            return getlist;
        }
        public string DeleteBanners(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Banners.DeleteBanners(id);

                return "true";
            }
            else
            {
                return "false";
            }

        }
        public Banners getbyidBanners(string id)
        {

            var get = _Banners.getbyidBanners(id);

            return get;


        }
    
    }
}
