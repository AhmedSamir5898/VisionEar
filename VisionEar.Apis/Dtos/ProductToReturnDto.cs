using VisionEar.Core.Entities;

namespace VisionEar.Apis.Dtos
{
    public class ProductToReturnDto
    {

        public string product_name { get; set; }
        public string description { get; set; }
        public string picture_url { get; set; }
        public decimal price { get; set; }
        public string currency { get; set; } 
        public string Brand_name { get; set; }
        public string Category_name{ get; set; }
        public string code { get; set; }
    }
}
