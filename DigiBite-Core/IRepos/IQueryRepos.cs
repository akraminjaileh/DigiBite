using System.Linq.Expressions;

namespace DigiBite_Core.IRepos
{
    public interface IQueryRepos
    {
        Task<T> GetById<T>(Expression<Func<T, bool>> predicate) where T : class;
        IQueryable<TResult> GetProjected<T, TResult>(Expression<Func<T, TResult>> resultSelector) where T : class;
        IQueryable<TResult> GetProjected<T1, T2, TKey, TResult>(Expression<Func<T1, TKey>> outerKeySelector, Expression<Func<T2, TKey>> innerKeySelector, Expression<Func<T1, T2, TResult>> resultSelector)
            where T1 : class
            where T2 : class;
        IQueryable<TResult> GetProjected<T1, T2, T3, TKey, TResult>(Expression<Func<T1, TKey>> outerKeySelector, Expression<Func<T2, TKey>> innerKeySelector, Expression<Func<T3, TKey>> thirdKeySelector, Expression<Func<T1, T2, T3, TResult>> resultSelector)
            where T1 : class
            where T2 : class
            where T3 : class;
        IQueryable<TResult> GetProjected<T1, T2, T3, T4, TKey, TResult>(Expression<Func<T1, TKey>> outerKeySelector, Expression<Func<T2, TKey>> innerKeySelector, Expression<Func<T3, TKey>> thirdKeySelector, Expression<Func<T4, TKey>> fourthKeySelector, Expression<Func<T1, T2, T3, T4, TResult>> resultSelector)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class;
    }
}
