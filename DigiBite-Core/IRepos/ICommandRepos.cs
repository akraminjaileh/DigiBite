

namespace DigiBite_Core.IRepos
{
    public interface ICommandRepos
    {
        Task<int> CreateAsync<T>(T entity) where T : class;
        Task<int> RemovePermanentlyAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
        Task<int> UpdateAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
    }
}
