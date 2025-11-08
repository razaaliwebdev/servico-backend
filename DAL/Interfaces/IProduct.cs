using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProduct
    {
       Task< Product> AddProducts(string title, string productID, string categories, string price, string brands, string spec, string multiimage, string singleimage, string shortdesc, string longdesc, string attributes ,string atvalue );
        Task<Product> AddProductsobj(Product obj);
        Task<List<Product>> GetAllProducts();

        Task<List<Subcategories>> GetAllSubCategoriesByID(string id);
        Product getbyidProducts(string id);

        Task<List<Product>> GetAllModelnoProducts(string id);
        Task<Product> UpdateProductsobj(Product obj);

        string DeleteProducts(string id);

        string publishproduct(string value, string id);
    }
}
