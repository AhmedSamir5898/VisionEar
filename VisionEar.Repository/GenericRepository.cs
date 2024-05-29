using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;
using VisionEar.Core.IRepository;
using VisionEar.Core.Specifications;
using VisionEar.Repository.Data;

namespace VisionEar.Repository
{
    public class GenericRepository<T> : IGenericRepositroy<T> where T : BaseEntity
    {
        private readonly StoreContext dbcontext;

        public GenericRepository(StoreContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

     
        

        public async Task<IReadOnlyList<T>> GetAllWithspecAsync(Ispecifications<T> spec)
        {
           return await Applyspec(spec).ToListAsync();
        }

        public async Task<T?> GetWithSpecAsync(Ispecifications<T> spec)
        {
             return await Applyspec(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> Applyspec (Ispecifications<T> spec)
        {
            return SpecificationsEvaluator<T>.GetQuery(dbcontext.Set<T>(), spec);
        }
    }
}
