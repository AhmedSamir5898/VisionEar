using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEar.Core.Entities
{
    public class Products : BaseEntity
    {
        public string product_name {  get; set; }
        public string description { get; set; }
        public string picture_url { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; } = "Pounds";
        public int brand_id { get; set; }
        public Brands Brands { get; set; }
        public int category_id { get; set; }
        public Categories? Categories { get; set; }
        public string code { get; set; }
    }
}
