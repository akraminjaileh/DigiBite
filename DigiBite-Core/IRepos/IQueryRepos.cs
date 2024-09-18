using System.Linq.Expressions;

namespace DigiBite_Core.IRepos
{
    public interface IQueryRepos
    {
        Task<IEnumerable<T>> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<T> GetById<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
