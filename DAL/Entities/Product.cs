using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }
        public string name { get; set; }
        [ForeignKey("Categories_ID")]
   
        public int? category_id { get; set; }

        public Categories? Categories { get; set; }

        [ForeignKey("Subid")]

        public int? Subid { get; set; }

        public virtual Subcategories? subCategories { get; set; }

        public string price { get; set; }

        [ForeignKey("Brand_ID")]
    
        public int? brand_id { get; set; }
        public virtual Brands? Brands { get; set; }
        public string specification { get; set; }
        public string specificationright { get; set; }

        public string Attributevalue { get; set; }
        public string shortdesc { get; set; }
        public string longdesc { get; set; }
        public string singleImage { get; set; }

        public string Images { get; set; }
        public string brandname { get; set; }
        public string categoryname { get; set; }

        public string subcategoryname { get; set; }

        public string variations  { get; set; }

        public string dod { get; set; }
        public string bs { get; set; }
        public string na { get; set; }
        public string fa { get; set; }

        public string modelno { get; set; }

        public string height { get; set; }
        public string width { get; set; }
        public string depth { get; set; }

        public string cbm { get; set; }

        public string cbmcalculation { get; set; }

        public string cl20gp { get; set; }

        public string cl40gp { get; set; }

        public string cl40hq { get; set; }

        public string minqty { get; set; }

        //seo
        public string keywords { get; set; }

        public string metadesc { get; set; }

        public string metatitle { get; set; }
        public string alttag { get; set; }

        public string draft { get; set; }
        public string compare { get; set; }
        public string three_d { get; set; }

    }
}
