using System.Linq.Expressions;

namespace DigiBite_Core.IRepos
{
    public interface IQueryRepos
    {
        Task<IEnumerable<T>> GetAll<T>(Expression<Func<T, bool>> predicate) where T : class;
        
        //Task<IEnumerable<TResult>> GetAll<T1, T2, TKey, TResult>(Expression<Func<T1, TKey>> outerKeySelector, Expression<Func<T2, TKey>> innerKeySelector, Expression<Func<T1, T2, TResult>> resultSelector)
        //    where T1 : class
        //    where T2 : class;
        IQueryable<TResult> GetAll<T1, T2, TKey, TResult>(Expression<Func<T1, TKey>> outerKeySelector, Expression<Func<T2, TKey>> innerKeySelector, Expression<Func<T1, T2, TResult>> resultSelector)
            where T1 : class
            where T2 : class;
        Task<T> GetById<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}
