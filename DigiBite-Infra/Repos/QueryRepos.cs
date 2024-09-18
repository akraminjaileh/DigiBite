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

        public async Task<T> GetById<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        }


    }
}
