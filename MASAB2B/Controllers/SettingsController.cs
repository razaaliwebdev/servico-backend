using DAL.DataContext;
using DAL.DataModels;
using DAL.Entities;
using DAL.Functions;
using LOGIC.SettingsLogic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MASAB2B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class SettingsController : ControllerBase
    {

        [Route("GetAllCategories")]
        [HttpGet]
        public async Task<List<Categories>> GetCategories()
        {
            CategoriesLogic cat = new CategoriesLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("SaveCategories")]
        [HttpPost]
        public Task<bool> SaveCategoriess(Categories obj)
        {
            CategoriesLogic cat = new CategoriesLogic();
            var get = cat.CreateNewCategory(obj.name, Convert.ToString(obj.Categories_ID),obj.slug);
            return get;


        }
 
        [Route("DeleteCategories")]
        [HttpGet] 
        public string DeleteCategories(string id)
        {

            CategoriesLogic cat = new CategoriesLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdCategories")]
        [HttpGet]
        public IActionResult GetByIdCategoriess(string id)
        {

            CategoriesLogic cat = new CategoriesLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }


        [Route("GetAllServiceCategories")]
        [HttpGet]
        public async Task<List<ServiceCategories>> GetServiceCategories()
        {
            ServiceCategoriesLogic cat = new ServiceCategoriesLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("SaveServiceCategories")]
        [HttpPost]
        public Task<bool> SaveServiceCategoriess(ServiceCategories obj)
        {
            ServiceCategoriesLogic cat = new ServiceCategoriesLogic();
            var get = cat.CreateNewCategory(obj.name, Convert.ToString(obj.id), obj.slug,obj.image);
            return get;


        }

        [Route("DeleteServiceCategories")]
        [HttpGet]
        public string DeleteServiceCategories(string id)
        {

            ServiceCategoriesLogic cat = new ServiceCategoriesLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdServiceCategories")]
        [HttpGet]
        public IActionResult GetByIdServiceCategoriess(string id)
        {

            ServiceCategoriesLogic cat = new ServiceCategoriesLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }
        [Route("GetAllSubCategories")]
        [HttpGet]
        public async Task<List<Subcategories>> GetSubCategories()
        {
            SubcategoryLogic cat = new SubcategoryLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("SaveSubCategories")]
        [HttpPost]
        public Task<bool> SaveSubCategoriess(Subcategories obj)
        {
            SubcategoryLogic cat = new SubcategoryLogic();
            var get = cat.CreateNewCategory(obj.name, Convert.ToString(obj.Subid), Convert.ToString(obj.category_id),obj.categoryname);
            return get;


        }

        [Route("DeleteSubCategories")]
        [HttpGet]
        public string DeleteSubCategories(string id)
        {

            SubcategoryLogic cat = new SubcategoryLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdSubCategories")]
        [HttpGet]
        public IActionResult GetByIdSubCategoriess(string id)
        {

            SubcategoryLogic cat = new SubcategoryLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }

        [Route("GetAlltyrebrand")]
        [HttpGet]
        public async Task<List<tyrebrand>> Gettyrebrand()
        {
            tyrebrandLogic cat = new tyrebrandLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("Savetyrebrand")]
        [HttpPost]
        public Task<bool> Savetyrebrand(tyrebrand obj)
        {
            tyrebrandLogic cat = new tyrebrandLogic();
            var get = cat.Add(Convert.ToString(obj.id),obj.countrybrand,obj.countrymade,obj.width,obj.height,obj.rimsize,obj.rimsize);
            return get;


        }

        [Route("Deletetyrebrands")]
        [HttpGet]
        public string Deletetyerbrand(string id)
        {

            tyrebrandLogic cat = new tyrebrandLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        //tyre brand price 

        [Route("GetAlltyrebrandprice")]
        [HttpGet]
        public async Task<List<tyrebrandprice>> Gettyrebrandprices()
        {
            TyrebrandspriceLogic cat = new TyrebrandspriceLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("Savetyrebrandprice")]
        [HttpPost]
        public Task<bool> Savetyrebrandprices(tyrebrandprice obj)
        {
            TyrebrandspriceLogic cat = new TyrebrandspriceLogic();
            var get = cat.Add(Convert.ToString(obj.id), obj.countrybrand, obj.countrymade, obj.width, obj.height, obj.rimsize, obj.rimsize,obj.price);
            return get;


        }


        [Route("Deletetyrebrandsprices")]
        [HttpGet]
        public string Deletetyerbrandpricess(string id)
        {

            TyrebrandspriceLogic cat = new TyrebrandspriceLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdtyrebrandprices")]
        [HttpGet]
        public IActionResult GetByIdtyrebrandpricess(string id)
        {

            TyrebrandspriceLogic cat = new TyrebrandspriceLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }
        [Route("GetByIdtyrebrand")]
        [HttpGet]
        public IActionResult GetByIdtyrebrand(string id)
        {

            tyrebrandLogic cat = new tyrebrandLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }
        [Route("GetAllServiceSubCategories")]
        [HttpGet]
        public async Task<List<ServiceSubcategories>> GetServiceSubCategories()
        {
            ServiceSubCategoriesLogic cat = new ServiceSubCategoriesLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("SaveServiceSubCategories")]
        [HttpPost]
        public Task<bool> SaveServiceSubCategoriess(ServiceSubcategories obj)
        {
            ServiceSubCategoriesLogic cat = new ServiceSubCategoriesLogic();
            var get = cat.CreateNewCategory(obj.name, Convert.ToString(obj.id), Convert.ToString(obj.category_id), obj.categoryname,obj.price,obj.image,obj.adminid);
            return get;


        }

        [Route("DeleteServiceSubCategories")]
        [HttpGet]
        public string DeleteServiceSubCategories(string id)
        {

            ServiceSubCategoriesLogic cat = new ServiceSubCategoriesLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdServiceSubCategories")]
        [HttpGet]
        public IActionResult GetByIdServiceSubCategoriess(string id)
        {

            ServiceSubCategoriesLogic cat = new ServiceSubCategoriesLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }
        [Route("GetAllAttributes")]
        [HttpGet]
        public async Task<List<Attributes>> GetAttributes()
        {
            AttributesLogic cat = new AttributesLogic();
            var list = await cat.GetAllAttributes();

            return list;

        }
        [Route("SaveAttributes")]
        [HttpPost]
        public IActionResult SaveAttribute(Attributes obj)
        {
            AttributesLogic att = new AttributesLogic();
            var get = att.CreateNewAttributes(obj.name, Convert.ToString(obj.AttributeID));
            return Ok();

        }
   
        [Route("DeleteAttributes")]
        [HttpPost]
        public IActionResult DeleteAttributes(string id)
        {

            AttributesLogic att = new AttributesLogic();
            var get = att.DeleteAttributes(id);
            return Ok();


        }
        [Route("GetByIdAttributes")]
        [HttpGet]
        public IActionResult GetByIdAttributess(string id)
        {

            AttributesLogic cat = new AttributesLogic();
            var get = cat.getbyidAttributes(id);
            return Ok(get);


        }
        [Route("GetAllBrands")]
        [HttpGet]
        public async Task<List<Brands>> GetBrands()
        {
            BrandsLogic brand = new BrandsLogic();
            var list = await brand.GetAllBrands();

            return list;

        }
        [Route("SaveBrands")]
        [HttpPost]
        public Task<bool> SaveBrands(Brands obj)
        {
            BrandsLogic brands = new BrandsLogic();
            var get = brands.CreateNewBrands(obj.name, Convert.ToString(obj.Brand_ID),obj.details,obj.Image);
            return get;

        }


        [Route("DeleteBrands")]
        [HttpGet]
        public string DeleteBrandss(string id)
        {

            BrandsLogic att = new BrandsLogic();
            var get = att.DeleteBrands(id);
            return get;


        }

        [Route("GetByIdBrands")]
        [HttpGet]
        public IActionResult GetByIdBrandss(string id)
        {

            BrandsLogic cat = new BrandsLogic();
            var get = cat.getbyidBrands(id);
            return Ok(get);


        }
        [HttpPost, DisableRequestSizeLimit]

        [Route("UploadBrands")]
        public async Task<string> Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "BrandImages");
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

        [Route("UploadSub")]
        public async Task<string> UploadSub1()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Serviceimages");
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

        [Route("UploadBanners")]
        public async Task<string> Uploadbanners()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "BannersImage");
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
                    string jsonString = JsonSerializer.Serialize(fullPath);
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
        [Route("GetAllBanners")]
        [HttpGet]
        public async Task<List<Banners>> GetBanners()
        {
            BannersLogic banner = new BannersLogic();
            var list = await banner.GetAllBanners();

            return list;

        }
        [Route("SaveBannerss")]
        [HttpPost]
        public Task<bool> SaveBanners(Banners obj)
        {
            BannersLogic banner = new BannersLogic();
            var get = banner.CreateNewBanners(Convert.ToString(obj.banner_ID),obj.bnum,obj.image,obj.value,obj.productid,obj.type);
            return get;

        }


        [Route("DeleteBanners")]
        [HttpGet]
        public string DeleteBanners(string id)
        {

            BannersLogic banner = new BannersLogic();
            var get = banner.DeleteBanners(id);
            return get;


        }

        [Route("GetByIdBanners")]
        [HttpGet]
        public IActionResult GetByIdBanners(string id)
        {
            BannersLogic banner = new BannersLogic();
            var get = banner.getbyidBanners(id);
            return Ok(get);


        }
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<List<Signup>> GetUsers()
        {
            SignupLogic users = new SignupLogic();
            var list = await users.GetAllSignup();

            return list;

        }
        [Route("SaveUserss")]
        [HttpPost]
        public Task<bool> SaveUsers(Signup obj)
        {
            SignupLogic users = new SignupLogic();
            var get = users.CreateNewUser(Convert.ToString(obj.id), obj.firstname, obj.lastname, obj.email, obj.phone, obj.password,  obj.type, obj.document1, obj.document2, obj.extra, obj.verification);
            return get;

        }


        [Route("DeleteUserss")]
        [HttpGet]
        public string DeleteUsers(string id)
        {

            SignupLogic user = new SignupLogic();
            var get = user.DeleteSignups(id);
            return get;


        }

        [Route("GetByIdUsers")]
        [HttpGet]
        public IActionResult GetByIdUserss(string id)
        {
            SignupLogic user = new SignupLogic();
            var get = user.getbyidSignups(id);
            return Ok(get);


        }
        [Route("Forgot")]
        [HttpPost]
        public string ForgotPassword(Signup obj)
        {
            SignupLogic user = new SignupLogic();
            var get = user.ForgotPassword(obj);
            return get;


        }
        [Route("GetUserByEmail")]
        [HttpPost]
        public  Signup GetLogins(Signup obj)
        {
            SignupLogic user = new SignupLogic();
            var get = user.Getlogin(obj);
            return  get;


        }
        [Route("GetAllContacts")]
        [HttpGet]
        public async Task<List<Contacts>> GetContact()
        {
            ContactLogic users = new ContactLogic();
            var list = await users.GetAllContact();

            return list;

        }
        [Route("SaveContacts")]
        [HttpPost]
        public Task<bool> SaveContact(Contacts obj)
        {
            ContactLogic users = new ContactLogic();
            var get = users.CreateNewUser(Convert.ToString(obj.id), obj.firstname, obj.lastname, obj.email, obj.phone, obj.subject,obj.desc);
            return get;

        }


        [Route("DeleteContacts")]
        [HttpGet]
        public string DeleteContact(string id)
        {

            ContactLogic user = new ContactLogic();
            var get = user.DeleteContacts(id);
            return get;


        }

        [Route("GetByIdContact")]
        [HttpGet]
        public IActionResult GetByIdContacts(string id)
        {
            ContactLogic user = new ContactLogic();
            var get = user.getbyidContacts(id);
            return Ok(get);


        }

        [Route("GetAllAdminUsers")]
        [HttpGet]
        public async Task<List<AdminUsers>> GetAdminUsers()
        {
            AdminUsersLogic users = new AdminUsersLogic();
            var list = await users.GetAllSignup();

            return list;

        }
        [Route("SaveAdminUserss")]
        [HttpPost]
        public Task<bool> SaveAdminUsers(AdminUsers obj)
        {
            AdminUsersLogic users = new AdminUsersLogic();
            var get = users.CreateNewUser(Convert.ToString(obj.id), obj.name, obj.type, obj.password);
            return get;

        }


        [Route("DeleteAdminUserss")]
        [HttpGet]
        public string DeleteAdminUsers(string id)
        {

            AdminUsersLogic user = new AdminUsersLogic();
            var get = user.DeleteSignups(id);
            return get;


        }

        [Route("GetByIdAdminUsers")]
        [HttpGet]
        public IActionResult GetByIdAdminUserss(string id)
        {
            AdminUsersLogic user = new AdminUsersLogic();
            var get = user.getbyidSignups(id);
            return Ok(get);


        }
        [Route("GetUserByAdminEmail")]
        [HttpPost]
        public AdminUsers GetAdminLogin(AdminUsers obj)
        {
            AdminUsersLogic user = new AdminUsersLogic();
            var get = user.Getlogin(obj);
            return get;


        }

        [Route("GetAllBlogs")]
        [HttpGet]
        public async Task<List<Blogs>> GetBlogs()
        {
            BlogsLogic brand = new BlogsLogic();
            var list = await brand.GetAllBlogs();

            return list;

        }
        [Route("SaveBlogss")]
        [HttpPost]
        public Task<bool> SaveBlogss(Blogs obj)
        {
            BlogsLogic brands = new BlogsLogic();
            var get = brands.CreateNewBlogs(Convert.ToString(obj.blogid), obj.title, obj.image,obj.desc,obj.metatitle,obj.metdesc,obj.keywords);
            return get;

        }


        [Route("DeleteBlogs")]
        [HttpGet]
        public string DeleteBlogss(string id)
        {

            BlogsLogic att = new BlogsLogic();
            var get = att.DeleteBlogs(id);
            return get;


        }

        [Route("GetByIdBlogss")]
        [HttpGet]
        public IActionResult GetByIdBlogs(string id)
        {

            BlogsLogic cat = new BlogsLogic();
            var get = cat.getbyidBlogs(id);
            return Ok(get);


        }
        [HttpPost, DisableRequestSizeLimit]

        [Route("UploadBlogss")]
        public async Task<string> UploadBlogs()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "Blogsimages");
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
        [Route("GetAllOtp")]
        [HttpGet]
        public async Task<List<Otp>> GetOtp()
        {
            OtpLogic brand = new OtpLogic();
            var list = await brand.GetAllOtp();

            return list;

        }
        [Route("SaveOtp")]
        [HttpPost]
        public Task<bool> SaveOtp(Otp obj)
        {
            OtpLogic brands = new OtpLogic();
            var get = brands.CreateNewOtp(obj.email, Convert.ToString(obj.id), obj.code);
            return get;

        }


        [Route("DeleteOtp")]
        [HttpGet]
        public string DeleteOtp(string id)
        {

            OtpLogic att = new OtpLogic();
            var get = att.DeleteOtp(id);
            return get;


        }

        [Route("GetByIdOtp")]
        [HttpGet]
        public IActionResult GetByIdOtp(string id)
        {

            OtpLogic cat = new OtpLogic();
            var get = cat.getbyidOtp(id);
            return Ok(get);


        }
        [Route("confirm")]
        [HttpGet]
        public IActionResult confirmation(string email)
        {

            Confirmation obj = new Confirmation();
           var value= obj.UpdateSignup(email);
            return Redirect("http://64.20.61.114/web/#/confirmuser");


        }

        [Route("GetAllMetaMain")]
        [HttpGet]
        public async Task<List<metamain>> GetMetaMain()
        {
            MetaMainLogic banner = new MetaMainLogic();
            var list = await banner.GetAllmetamains();

            return list;

        }
        [Route("SaveMetaMain")]
        [HttpPost]
        public Task<bool> SaveMetaMains(metamain obj)
        {
            MetaMainLogic banner = new MetaMainLogic();
            var get = banner.CreateNewmetamains(Convert.ToString(obj.id), obj.bnum, obj.metatitle, obj.metadesc, obj.metakeyword);
            return get;

        }


        [Route("DeleteMetaMain")]
        [HttpGet]
        public string DeleteMetaMainss(string id)
        {

            MetaMainLogic banner = new MetaMainLogic();
            var get = banner.Deletemetamains(id);
            return get;


        }

        [Route("GetByIdMetaMain")]
        [HttpGet]
        public IActionResult GetByIdMetaMainss(string id)
        {
            MetaMainLogic banner = new MetaMainLogic();
            var get = banner.getbyidmetamains(id);
            return Ok(get);


        }
        [HttpPost, DisableRequestSizeLimit]

        [Route("UploadBannersdod")]
        public async Task<string> Uploadbannersdod()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Images", "BannersImage");
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
        [Route("GetAllBannersdod")]
        [HttpGet]
        public async Task<List<DOD>> GetBannersdod()
        {
            DODLogic banner = new DODLogic();
            var list = await banner.GetAllBanners();

            return list;

        }
        [Route("SaveBannerssdod")]
        [HttpPost]
        public Task<bool> SaveBannersdod(DOD obj)
        {
            DODLogic banner = new DODLogic();
            var get = banner.CreateNewBanners(Convert.ToString(obj.banner_ID), obj.bnum, obj.image, obj.value, obj.productid, obj.type,obj.details, obj.dealcounter,obj.price);
            return get;

        }


        [Route("DeleteBannersdods")]
        [HttpGet]
        public string DeleteBannersdod(string id)
        {

            DODLogic banner = new DODLogic();
            var get = banner.DeleteBanners(id);
            return get;


        }

        [Route("GetByIdBannersdod")]
        [HttpGet]
        public IActionResult GetByIdBannersdod(string id)
        {
            DODLogic banner = new DODLogic();
            var get = banner.getbyidBanners(id);
            return Ok(get);


        }

        [Route("GetAllWhishList")]
        [HttpGet]
        public async Task<List<WhishList>> Get()
        {
            WhishListLogic banner = new WhishListLogic();
            var list = await banner.GetAll();

            return list;

        }
        [Route("Savewhish")]
        [HttpPost]
        public Task<bool> SaveWhishList(WhishList obj)
        {
            WhishListLogic banner = new WhishListLogic();
            var get = banner.CreateNew(Convert.ToString(obj.whishid), Convert.ToString(obj.product_id), Convert.ToString(obj.id));
            return get;

        }


        [Route("Deletewhish")]
        [HttpGet]
        public string Deletewhishlist(string id,string userid)
        {

            WhishListLogic banner = new WhishListLogic();
            var get = banner.Deletewhishlist(id,userid);
            return get;


        }

        [Route("GetByIdwhish")]
        [HttpGet]
        public IActionResult GetById(string id)
        {
            WhishListLogic banner = new WhishListLogic();
            var get = banner.getbyid(id);
            return Ok(get);
        }

        [Route("GetAllServices")]
        [HttpGet]
        public async Task<List<Services>> GetServices()
        {
            ServicesLogic banner = new ServicesLogic();
            var list = await banner.GetAllServices();

            return list;

        }

   
        [Route("SaveService")]
        [HttpPost]
        public Task<bool> SaveServices(Services obj)
        {

            ServicesLogic banner = new ServicesLogic();
            var get = banner.AddServices(Convert.ToString(obj.id), obj.title,  obj.type,  obj.location,  obj.emirates, Convert.ToString(obj.opentime), Convert.ToString(obj.closetime), obj.img,  Convert.ToString(obj.expiry), Convert.ToString( obj.admin), Convert.ToString( obj.id), obj.catname, obj.subid, obj.subname, obj.username,  obj.password,obj.phone);
            return get;

        }


        [Route("DeleteService")]
        [HttpGet]
        public string DeleteService(string id)
        {


            ServicesLogic banner = new ServicesLogic();
            var get = banner.DeleteServices(id);
            return get;


        }

        [Route("GetByIdService")]
        [HttpGet]
        public IActionResult GetByIdServicess(string id)
        {

            ServicesLogic banner = new ServicesLogic();
            var get = banner.getbyidServices(id);
            return Ok(get);


        }
        [Route("GetAllBooking")]
        [HttpGet]
        public async Task<List<Booking>> GetBookings()
        {
            BookingLogic users = new BookingLogic();
            var list = await users.GetAllbooking();

            return list;

        }
        [Route("SaveBookings")]
        [HttpPost]
        public Task<bool> SaveBooking(Booking obj)
        {
            BookingLogic users = new BookingLogic();
            var get = users.CreateNewUser(Convert.ToString(obj.id), obj.fullname, obj.phone, obj.email, obj.date, obj.time, obj.area, obj.city, obj.state, obj.code, obj.shopid);
            return get;

        }


        [Route("DeleteBookings")]
        [HttpGet]
        public string Deletebooking(string id)
        {

            BookingLogic user = new BookingLogic();
            var get = user.DeleteBookings(id);
            return get;


        }

        [Route("GetByIdBooking")]
        [HttpGet]
        public IActionResult GetByIdBookings(string id)
        {
            BookingLogic user = new BookingLogic();
            var get = user.getbyidBookings(id);
            return Ok(get);


        }
        [Route("GetAlltyreimageBrands")]
        [HttpGet]
        public async Task<List<Tyrebrandimage>> GettyreimagesBrands()
        {
            TyreBrandImagesLogic brand = new TyreBrandImagesLogic();
            var list = await brand.GetAllBrands();

            return list;

        }
        [Route("SavetyreimageBrands")]
        [HttpPost]
        public Task<bool> SavetyreimageBrands(Tyrebrandimage obj)
        {
            TyreBrandImagesLogic brands = new TyreBrandImagesLogic();
            var get = brands.CreateNewBrands(obj.name, Convert.ToString(obj.Brand_ID), obj.Image);
            return get;

        }


        [Route("DeletetyreimageBrands")]
        [HttpGet]
        public string DeletetyreimageBrandss(string id)
        {

            TyreBrandImagesLogic att = new TyreBrandImagesLogic();
            var get = att.DeleteBrands(id);
            return get;


        }

        [Route("GetByIdtyreimageBrands")]
        [HttpGet]
        public IActionResult GetByIdtyreimageBrandss(string id)
        {

            TyreBrandImagesLogic cat = new TyreBrandImagesLogic();
            var get = cat.getbyidBrands(id);
            return Ok(get);


        }




        [Route("GetAllServicPrice")]
        [HttpGet]
        public async Task<List<ServicePrice>> GetServicePrices()
        {
            ServicePriceLogic cat = new ServicePriceLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("SaveServicePrice")]
        [HttpPost]
        public Task<bool> SaveServicePrices(ServicePrice obj)
        {
            ServicePriceLogic cat = new ServicePriceLogic();
            var get = cat.Add(obj.id+"",obj.staffless,obj.staffmore,obj.categoryname,obj.subcategoryname,obj.servicename,obj.servicecompanyname,obj.servicecompanyid,obj.price);
            return get;


        }

        [Route("DeleteServicePrice")]
        [HttpGet]
        public string DeleteServicePrices(string id)
        {

            ServicePriceLogic cat = new ServicePriceLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdServicePrice")]
        [HttpGet]
        public IActionResult GetByIdServicePRices(string id)
        {

            ServicePriceLogic cat = new ServicePriceLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }




        [Route("GetAllcarfilter")]
        [HttpGet]
        public async Task<List<Carfilters>> Getcarfilter()
        {
            CarfiltersLogic cat = new CarfiltersLogic();
            var list = await cat.GetAllCategories();

            return list;

        }
        [Route("SaveAllCarfilter")]
        [HttpPost]
        public Task<bool> SaveServicePrices(Carfilters obj)
        {
            CarfiltersLogic cat = new CarfiltersLogic();
            var get = cat.Add(obj.id + "", obj.year, obj.make,obj.model, obj.bodytype, obj.fueltype,obj.makeimage);
            return get;


        }

        [Route("DeleteCarfilter")]
        [HttpGet]
        public string DeleteCarfilters(string id)
        {

            CarfiltersLogic cat = new CarfiltersLogic();
            var get = cat.DeleteCategoriess(id);
            return get;


        }
        [Route("GetByIdcarfilter")]
        [HttpGet]
        public IActionResult GetByIdcarfilters(string id)
        {

            CarfiltersLogic cat = new CarfiltersLogic();
            var get = cat.getbyidCategoriess(id);
            return Ok(get);


        }

        [Route("GetAllVehicles")]
        [HttpGet]
        public async Task<List<Vehicle>> GetVehicles()
        {
            VehicleLogic cat = new VehicleLogic();
            var list = await cat.GetAll();

            return list;
        }
        
        [Route("Savevehicle")]
        [HttpPost]
        public Task<bool> Savevehicles(Vehicle obj)
        {
            VehicleLogic cat = new VehicleLogic();
            var get = cat.Add(obj.id + "", obj.category, obj.make, obj.model, obj.year, obj.numberplate);
            return get;


        }

        [Route("DeleteVehicle")]
        [HttpGet]
        public string DeleteVehicels(string id)
        {

            VehicleLogic cat = new VehicleLogic();
            var get = cat.Delete(id);
            return get;


        }
        [Route("GetByIdVehcless")]
        [HttpGet]
        public IActionResult GetByIdVehicles(string id)
        {

            VehicleLogic cat = new VehicleLogic();
            var get = cat.getbyid(id);
            return Ok(get);


        }

        [Route("GetAllDriver")]
        [HttpGet]
        public async Task<List<Driver>> GetDrivers()
        {
            DriverLogic cat = new DriverLogic();
            var list = await cat.GetAll();

            return list;
        }

        [Route("Savedriver")]
        [HttpPost]
        public Task<bool> Savedriver(Driver obj)
        {
            DriverLogic cat = new DriverLogic();
            var get = cat.Add(obj.id + "", obj.name, obj.image, obj.opentime, obj.closetime, obj.expiry,obj.email,obj.password,obj.vid);
            return get;


        }

        [Route("Deletedriver")]
        [HttpGet]
        public string Deletedrivers(string id)
        {

            DriverLogic cat = new DriverLogic();
            var get = cat.Delete(id);
            return get;


        }
        [Route("GetByIddriverss")]
        [HttpGet]
        public IActionResult GetByIddrivers(string id)
        {


            DriverLogic cat = new DriverLogic();
            var get = cat.getbyid(id);
            return Ok(get);


        }

    }

}
