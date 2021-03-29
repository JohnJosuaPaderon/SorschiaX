using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sorschia.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> IncludeIf<TEntity, TProperty>(this IQueryable<TEntity> instance, Expression<Func<TEntity, TProperty>> navigationPropertyPath, bool? condition)
            where TEntity : class
        {
            if (condition ?? false)
                return instance.Include(navigationPropertyPath);

            return instance;
        }
    }

    public static class IEnumerableExtensions
    {
        public static IEnumerable<TEntity> WhereIf<TEntity>(this IEnumerable<TEntity> instance, Func<TEntity, bool> predicate, bool? condition)
        {
            if (condition ?? false)
                return instance.Where(predicate);

            return instance;
        }
    }
}
