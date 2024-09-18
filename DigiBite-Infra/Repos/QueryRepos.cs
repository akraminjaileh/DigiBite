using DigiBite_Core.Context;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigiBite_Infra.Repos
{
    public class QueryRepos(DigiBiteContext context) : IQueryRepos
    {

        public async Task<IEnumerable<T>> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();

        }

        public IQueryable<TResult> GetAll<T1, T2, TKey, TResult>(
        Expression<Func<T1, TKey>> outerKeySelector,
        Expression<Func<T2, TKey>> innerKeySelector,
        Expression<Func<T1, T2, TResult>> resultSelector)
        where T1 : class
        where T2 : class
        {
            return  context.Set<T1>()
                .Join(
                    context.Set<T2>(),
                    outerKeySelector, 
                    innerKeySelector, 
                    resultSelector   
                ).AsQueryable();
        }


        public async Task<T> GetById<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        }


    }
}
