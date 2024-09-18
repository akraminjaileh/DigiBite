using DigiBite_Core.Context;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigiBite_Infra.Repos
{
    public class CommandRepos(DigiBiteContext context) : ICommandRepos
    {
        public async Task<int> CreateAsync<T>(T entity) where T : class
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var entity = context.Set<T>().FirstOrDefault(predicate);

            if (entity is null) return 0;

            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> RemovePermanentlyAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var entity = context.Set<T>().FirstOrDefault(predicate);

            if (entity is null) return 0;
            
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

    }
}
