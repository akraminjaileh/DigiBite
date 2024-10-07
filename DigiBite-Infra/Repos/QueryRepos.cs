using DigiBite_Core.Context;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace DigiBite_Infra.Repos
{
    public class QueryRepos(DigiBiteContext context) : IQueryRepos
    {

        public async Task<T> GetEntityAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {

            try
            {
                var entity = await context.Set<T>().FirstOrDefaultAsync(predicate);

                if (entity == null)
                    throw new KeyNotFoundException($"'{typeof(T).Name}' not found.");

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<T>> GetEntitiesAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {

            try
            {
                return await context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
