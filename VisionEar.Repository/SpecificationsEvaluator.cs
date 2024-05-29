using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;
using VisionEar.Core.Specifications;

namespace VisionEar.Repository
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery ,Ispecifications<TEntity> Spec)
        {
            var query = inputQuery;
            if (Spec.Critaria is not null)
                query = query.Where(Spec.Critaria);
            query = Spec.Includes.Aggregate(query, (CurrentQuery, IncludesExpression) => CurrentQuery.Include(IncludesExpression));
            return query;
        }
    }
}
