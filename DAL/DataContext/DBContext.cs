using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class DBContext: DbContext
    {
        public DBContext()
        {

        }
        public class OptionBuild
        {
            public OptionBuild()
            {
                settings = new AppConfiguration();
                opsbuilder = new DbContextOptionsBuilder<DBContext>();
                opsbuilder.UseSqlServer(settings.sqlconnectionstring);
                dboptions = opsbuilder.Options;
            
            }
            public DbContextOptionsBuilder<DBContext> opsbuilder { get; set; }
            public DbContextOptions<DBContext> dboptions { get; set; }
            private AppConfiguration settings { get; set; }

        }
        public static OptionBuild ops = new OptionBuild();
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
       public DbSet<Categories> categories
       {
           get; set;
        }

        public DbSet<Attributes> attributes
        {
            get; set;
        }

        public DbSet<Brands> brandss
        {
            get; set;
        }
        public DbSet<Product> productss
        {
            get; set;
        }
        public DbSet<Subcategories> subcategoriess
        {
            get; set;
        }
        public DbSet<Orders> Orderss
        {
            get; set;
        }
        public DbSet<OrderItems> OrderItemss
        {
            get; set;
        }
        public DbSet<Banners> bannerss
        {
            get; set;
        }
        public DbSet<Signup> signups
        {
            get; set;
        }
        public DbSet<Queries> queriess
        {
            get; set;
        }
        public DbSet<Contacts> contactss
        {
            get; set;
        }
        public DbSet<AdminUsers> adminuserss
        {
            get; set;
        }
        public DbSet<Blogs> Blogss
        {
            get; set;
        }
        public DbSet<Otp> Otps
        {
            get; set;
        }
        public DbSet<metamain> metamains

        {
            get; set;
        }
        public DbSet<DOD> dods

        {
            get; set;
        }

        public DbSet<WhishList> whish

        {
            get; set;
        }

        public DbSet<rating> ratings

        {
            get; set;
        }

        public DbSet<Services> servicess

        {
            get; set;
        }
        public DbSet<ServiceCategories> servicecategoriess

        {
            get; set;
        }
        public DbSet<ServiceSubcategories> servicesubcategoriess

        {
            get; set;
        }
        public DbSet<Booking> bookingss

        {
            get; set;
        }
        public DbSet<tyrebrand> tyrebrands

        {
            get; set;
        }
        public DbSet<tyrebrandprice> tyrebrandprices

        {
            get; set;
        }
        public DbSet<Tyrebrandimage> tyrebrandimages

        {
            get; set;
        }

        public DbSet<ServicePrice> seriviceprices

        {
            get; set;
        }


        public DbSet<Carfilters> carfilterss

        {
            get; set;
        }
        public DbSet<Vehicle> vehicles

        {
            get; set;
        }
        public DbSet<Driver> drivers

        {
            get; set;
        }
    }

}
