using DAL.Entities;
using LOGIC.SettingsLogic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace MASAB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductsController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductsController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        [Route("GetAllProducts")]
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            ProductsLogic pro = new ProductsLogic();
            var list = await pro.GetAllProducts();

            return list;

        }
      
        [Route("SaveProducts")]
        [HttpPost]
        
        public string SaveProduct(Product obj)
        {

            
            ProductsLogic pro = new ProductsLogic();

            var get = pro.CreateNewProductobj(obj);
            var pid = get.Result.Product_ID;
            if ( pid > 0)
            {
                return pid.ToString() ;
            }
            else
            {
                return "false";
            }
         
           


        }
   
        [HttpPost, DisableRequestSizeLimit]
    
        [Route("UploadProductss")]
        public async Task<string> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "SingleImages");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    string jsonString = JsonSerializer.Serialize(dbPath);
                    return jsonString;
                }
                else
                {
                    return "Bad Request";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        [HttpPost, DisableRequestSizeLimit]

        [Route("MultiImageUpload")]
        public  IActionResult Upload2()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Images", "MultipleImages");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dbpatreturn = "";
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Replace(",","").Replace(" ", "").Trim('"');
                   
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    if (string.IsNullOrEmpty(dbpatreturn))
                    {
                        dbpatreturn = dbPath;
                    }
                    else
                    {
                        dbpatreturn = dbPath + "," + dbpatreturn;
                    }
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                var pathjson = JsonSerializer.Serialize(dbpatreturn);
                return Ok(pathjson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "false");
            }
        }

        [HttpPost, DisableRequestSizeLimit]

        [Route("serviceimageupload")]
        public IActionResult Upload3()
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("Images", "Serviceimages");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dbpatreturn = "";
                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Replace(",", "").Replace(" ", "").Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require
                    if (string.IsNullOrEmpty(dbpatreturn))
                    {
                        dbpatreturn = dbPath;
                    }
                    else
                    {
                        dbpatreturn = dbPath + "," + dbpatreturn;
                    }
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                var pathjson = JsonSerializer.Serialize(dbpatreturn);
                return Ok(pathjson);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "false");
            }
        }
        [Route("GetAllSubCategoriesbycategory")]
        [HttpGet]
        public async Task<List<Subcategories>> GetAllSubCategoriesByID(string id)
        {
            ProductsLogic cat = new ProductsLogic();
            var list = await cat.GetAllSubCategoriesByID(id);

            return list;

        }
        [Route("GetByIdProducts")]
        [HttpGet]
        public IActionResult GetByIdProductss(string id)
        {

            ProductsLogic cat = new ProductsLogic();
            var get = cat.getbyidProductss(id);
            return Ok(get);


        }

        [Route("DeleteProducts")]
        [HttpGet]
        public string DeleteProducts(string id)
        {

            ProductsLogic cat = new ProductsLogic();
            var get = cat.DeleteProductss(id);
            return get;


        }
        [Route("GetByModelnoProducts")]
        [HttpGet]
        public async Task<List<Product>> GetByModelNoProductss(string id)
        {

            ProductsLogic cat = new ProductsLogic();
            var get =await cat.getbyModelnoProductss(id);
            return get;


        }
        [Route("Publish")]
        [HttpGet]
        public string publishproduct(string value,string id)
        {

            ProductsLogic cat = new ProductsLogic();
            var get =  cat.publishproduct(value,id);
            return get;


        }


    }
}
