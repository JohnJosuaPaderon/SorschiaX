using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Linq
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> AsNoTrackingIf<TEntity>(this IQueryable<TEntity> instance, bool condition) where TEntity : class
        {
            return condition ? instance.AsNoTracking() : instance;
        }

        public static int? CountIf<TEntity>(this IQueryable<TEntity> instance, bool condition) where TEntity : class
        {
            return condition ? instance.Count() : null;
        }

        public static int? CountIf<TEntity>(this IQueryable<TEntity> instance, Expression<Func<TEntity, bool>> predicate, bool condition) where TEntity : class
        {
            return condition ? instance.Count(predicate) : null;
        }

        public static async Task<int?> CountIfAsync<TEntity>(this IQueryable<TEntity> instance, bool condition, CancellationToken cancellationToken = default) where TEntity : class
        {
            return condition ? await instance.CountAsync(cancellationToken) : null;
        }

        public static async Task<int?> CountIfAsync<TEntity>(this IQueryable<TEntity> instance, Expression<Func<TEntity, bool>> predicate, bool condition, CancellationToken cancellationToken = default) where TEntity : class
        {
            return condition ? await instance.CountAsync(predicate, cancellationToken) : null;
        }

        public static IQueryable<T> TrySkip<T>(this IQueryable<T> instance, int? count)
        {
            if (count > 0)
                return instance.Skip(count.Value);

            return instance;
        }

        public static IQueryable<T> TryTake<T>(this IQueryable<T> instance, int? count)
        {
            if (count > 0)
                return instance.Take(count.Value);

            return instance;
        }

        public static IQueryable<TEntity> WhereIf<TEntity>(this IQueryable<TEntity> instance, Expression<Func<TEntity, bool>> predicate, bool condition) where TEntity : class
        {
            return condition ? instance.Where(predicate) : instance;
        }
    }
}
