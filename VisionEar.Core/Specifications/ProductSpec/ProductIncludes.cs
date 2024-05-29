using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;

namespace VisionEar.Core.Specifications.ProductSpec
{
    public class ProductIncludes :BaseSpecifications<Products> 
    {
        public ProductIncludes():base()
        {
            Includes();

        }

       

        public ProductIncludes(string code):base(P=>P.code == code)
        {
            Includes();
        }

        private void Includes()
        {
            base.Includes.Add(P => P.Brands);
            base.Includes.Add(P => P.Categories);
        }
    }
}
