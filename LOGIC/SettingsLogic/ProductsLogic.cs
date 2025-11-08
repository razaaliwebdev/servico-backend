using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;


namespace LOGIC.SettingsLogic
{
    public class ProductsLogic
    {
       
     
        private IProduct _Products = new DAL.Functions.ProductsFuntion();
        public async Task<Boolean> CreateNewProduct(string title, string productID, string categories, string price, string brands, string spec, string multiimage, string singleimage, string shortdesc, string longdesc, string attributes , string atvalue)
        {
            try
            {
                var result = await _Products.AddProducts( title,  productID,  categories,  price,  brands,  spec,  multiimage,  singleimage,  shortdesc,  longdesc,  attributes, atvalue);
                if (result.Product_ID > 0)
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
        public async Task<Product> CreateNewProductobj(Product obj)
        {
            
            try
            {
                if (obj.Product_ID != 0)
                {
                    var result = await _Products.UpdateProductsobj(obj);
                    if (result.Product_ID > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return new Product(); 
                    }
                }
                else
                {
                   
                    var result = await _Products.AddProductsobj(obj);
                    if (result.Product_ID > 0)
                    {
                      
                     
                        //   CookieOptions options = new CookieOptions();
                        // options.Expires = DateTime.Now.AddDays(1);
                        // _httpContextAccessor.HttpContext.Response.Cookies.Append("productid", result.Product_ID,options);
                        return result;
                    }
                    else
                    {
                        return new Product();
                    }
                }

        
            }
            catch (Exception error)
            {
                return new Product();
            }
        }
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> getlist = await _Products.GetAllProducts();
            return getlist;
        }
        public async Task<List<Subcategories>> GetAllSubCategoriesByID(string id) 
        {
            if (!string.IsNullOrEmpty(id))
            {
                List<Subcategories> getlist = await _Products.GetAllSubCategoriesByID(id);
                return getlist;

            }
            else
            {
                List<Subcategories> obj = new List<Subcategories>();
                return obj;
            }
         
        }

        public Product getbyidProductss(string id)
        {

            var get = _Products.getbyidProducts(id);

            return get;


        }
        public string publishproduct(string value, string id)
        {

            var get = _Products.publishproduct(value,id);

            return get;


        }
       

        public async Task<List<Product>>  getbyModelnoProductss(string id)
        {

            List<Product> get =await _Products.GetAllModelnoProducts(id);

            return get;


        }
        public string DeleteProductss(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var get = _Products.DeleteProducts(id);

                return get;
            }
            else
            {
                return "false";
            }

        }

    }
}
