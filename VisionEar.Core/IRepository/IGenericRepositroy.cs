using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;
using VisionEar.Core.Specifications;

namespace VisionEar.Core.IRepository
{
    public interface IGenericRepositroy <T> where T :BaseEntity
    {
        Task<T?> GetWithSpecAsync(Ispecifications<T> spec);
        Task <IReadOnlyList<T>> GetAllWithspecAsync(Ispecifications<T> spec);
       
    }
}
