using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LOGIC.SettingsLogic
{
    public class RatingLogic
    {
        private IRating _rating = new DAL.Functions.RatingFunctions();
        public async Task<string> CreateNewrating(rating rating)
        {
            try
            {
                /*   if (!string.IsNullOrEmpty(rating_ID) && Convert.ToInt64(rating_ID) > 0)
                   {
                       var get = _rating(name, rating_ID);
                       if (get.Id > 0)
                       {
                           return true;
                       }
                       else
                       {
                           return false;
                       }

                   }*/
                //    else
                //      {
                var result = await _rating.Addratings(rating);
                if (result.id > 0)
                {
                    return result.id.ToString();
                }
                else
                {
                    return "false";
                }

                // }

            }
            catch (Exception error)
            {
                return "false";
            }
        }

        public async Task<List<rating>> GetAllrating()
        {
            List<rating> getlist = await _rating.GetAllratings();
            return getlist;
        }

        public string Deleteratings(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _rating.Deleteratings(id);

                return get;
            }
            else
            {
                return "";
            }

        }
        public rating getbyidratings(string id)
        {

            var get = _rating.getbyidratings(id);

            return get;


        }
    }
}
