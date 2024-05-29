using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;

namespace VisionEar.Core.Specifications
{
    public interface Ispecifications<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>> Critaria { get; set; }
        public List<Expression<Func<T,object>>> Includes { get;set; }

     
    }
}
