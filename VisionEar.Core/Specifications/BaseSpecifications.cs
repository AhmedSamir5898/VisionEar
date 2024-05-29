using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;

namespace VisionEar.Core.Specifications
{
    public class BaseSpecifications<T> : Ispecifications<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Critaria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();


        public BaseSpecifications()
        {
        }
        public BaseSpecifications(Expression<Func<T,bool>> critaria)
        {
            Critaria = critaria;
        }
    }
}

   
    
    
    
