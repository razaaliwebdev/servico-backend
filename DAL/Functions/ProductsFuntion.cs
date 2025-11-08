using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class ProductsFuntion :IProduct
    {

        public async Task<Product> AddProducts(string  title, string  productID, string  categories, string  price, string brands, string spec, string multiimage, string singleimage, string shortdesc, string longdesc, string attributes,string attributevalue)
        {
            Product newProduct = new Product

            {
                name = title,
                Product_ID = Convert.ToInt32(productID),
                category_id = Convert.ToInt32(categories),
                price = price,
                brand_id = Convert.ToInt32(brands),
                specification = spec,
                Images = multiimage,
                singleImage = singleimage,
                shortdesc = shortdesc,
                longdesc = longdesc,
               
               




            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                try
                {
                    await context.productss.AddAsync(newProduct);
                    var res = await context.SaveChangesAsync();
                    var check = res;
                }
                catch (Exception e)
                { 
               
                }
            
            }

            return newProduct;

        }
        public async Task<Product> AddProductsobj(Product obj)
        {
            Product newProduct = new Product

            {
                name = obj.name,
                Attributevalue = obj.Attributevalue,
                brandname = obj.brandname,
                categoryname = obj.categoryname,
                subcategoryname = obj.subcategoryname,
                Subid = obj.Subid,
                category_id = Convert.ToInt32(obj.category_id),
                price = obj.price,
                brand_id = Convert.ToInt32(obj.brand_id),
                specification = obj.specification,
                Images = obj.Images,
                singleImage = obj.singleImage,
                shortdesc = obj.shortdesc,
                longdesc = obj.longdesc,
                variations = obj.variations,
                dod = obj.dod,
                na = obj.na,
                fa = obj.fa,
                bs = obj.bs,
                modelno = obj.modelno,
                specificationright = obj.specificationright,
                height = obj.height,
                width = obj.width,
                depth = obj.depth,
                cl20gp = obj.cl20gp,
                cl40gp = obj.cl40gp,
                cl40hq = obj.cl40hq,
                cbm = obj.cbm,
                cbmcalculation = obj.cbmcalculation,
                minqty = obj.minqty,
                keywords = obj.keywords,
                metadesc = obj.metadesc,
                metatitle = obj.metatitle,
                alttag = obj.alttag,
               draft = obj.draft,
               compare=obj.compare,
               three_d=obj.three_d

            };
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                try
                {
                    context.productss.Add(newProduct);
                    var res = await context.SaveChangesAsync();
                    var check = res;
                }
                catch (Exception e)
                {

                }

            }

            return newProduct;

        }
        public async Task<Product> UpdateProductsobj(Product obj)
        {
     
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                try
                {
                    var get = context.productss.FirstOrDefault(x => x.Product_ID == Convert.ToInt64(obj.Product_ID));
                    get.name = obj.name;
                    get.Attributevalue = obj.Attributevalue;
                    get.brandname = obj.brandname;
                    get.categoryname = obj.categoryname;
                    get.subcategoryname = obj.subcategoryname;
                    get.Subid = obj.Subid;
                    get.category_id = Convert.ToInt32(obj.category_id);
                    get.price = obj.price;
                    get.brand_id = Convert.ToInt32(obj.brand_id);
                    get.specification = obj.specification;
                    get.Images = obj.Images;
                    get.singleImage = obj.singleImage;
                    get.shortdesc = obj.shortdesc;
                    get.longdesc = obj.longdesc;
                    get.variations = obj.variations;
                    get.dod = obj.dod;
                    get.na = obj.na;
                    get.fa = obj.fa;
                      get.bs = obj.bs;
                    get.modelno = obj.modelno;
                    get.specificationright = obj.specificationright;
                    get.height = obj.height;
                    get.width = obj.width;
                    get.depth = obj.depth;
                    get.cbm = obj.cbm;
                    get.cl20gp = obj.cl20gp;
                    get.cl40gp = obj.cl40gp;
                    get.cl40hq = obj.cl40hq;
                    get.cbmcalculation = obj.cbmcalculation;
                    get.minqty = obj.minqty;
                    get.keywords=obj.keywords;
                    get.metadesc = obj.metadesc;
                    get.metatitle = obj.metatitle;
                    get.alttag = obj.alttag;
                    get.draft = obj.draft;
                    get.compare = obj.compare;
                    get.three_d = obj.three_d;
                    context.productss.Update(get);
                   
                    var res = await context.SaveChangesAsync();
                    var check = res;
                }
                catch (Exception e)
                {

                }

            }

            return obj;

        }

        public  string publishproduct(string value,string id)
        {

            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                try
                {
                    var get = context.productss.FirstOrDefault(x => x.Product_ID == Convert.ToInt64(id));
                    if (value == "no")
                    {
                        get.draft = "true";
                    }
                    else
                    {
                        get.draft = "false";
                    }
                   
                    context.productss.Update(get);

                    var res =  context.SaveChanges();
                    var check = res;
             
                }
                catch (Exception e)
                {

                }

            }

            return "true";

        }
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                products = await context.productss.OrderByDescending(s => s.Product_ID).ToListAsync();
               // products = await context.productss.GroupBy(x => x.modelno).Select(g => g.OrderByDescending(s => s.Product_ID).FirstOrDefault()).ToListAsync();

            }
            return products;
        }
        public async Task<List<Product>> GetAllModelnoProducts(string modelno)
        {
            List<Product> products = new List<Product>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                products = await context.productss.Where(x=>x.modelno == modelno).ToListAsync();

            }
            return products;
        }
        
        public async Task<List<Subcategories>> GetAllSubCategoriesByID(string id)
        {
            List<Subcategories> products = new List<Subcategories>();
            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                products = await context.subcategoriess.Where(x=>x.category_id == Convert.ToInt16(id)).ToListAsync();

            }
            return products;
        }
        public Product getbyidProducts(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.productss.FirstOrDefault(x => x.Product_ID == Convert.ToInt64(id));

                return getbyID;


            }
        }
        public string DeleteProducts(string id)
        {


            using (var context = new DBContext(DBContext.ops.dboptions))
            {
                var getbyID = context.productss.FirstOrDefault(x => x.Product_ID == Convert.ToInt64(id));
                if (getbyID != null)
                {
                    context.Remove(getbyID);
                    context.SaveChanges();


                    return "true";

                }
                else
                {
                    return "false";
                }



            }
        }

    }
}
