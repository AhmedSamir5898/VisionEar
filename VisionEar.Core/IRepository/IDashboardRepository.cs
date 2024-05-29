using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;

namespace VisionEar.Core.IRepository
{
    public interface IDashboardRepository<T> where T :BaseEntity
    {

        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
