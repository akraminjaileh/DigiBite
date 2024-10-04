

namespace DigiBite_Core.IRepos
{
    public interface ICommandRepos
    {
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> AddRangAsync<T>(IEnumerable<T> entity) where T : class;
        Task<int> RemovePermanentlyAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
        Task<int> RemoveRangPermanentlyAsync<T>(IEnumerable<T> input, System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
        Task<int> RemoveRangPermanentlyAsync<T>(IEnumerable<T> input) where T : class;
        Task<int> UpdateAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
    }
}
