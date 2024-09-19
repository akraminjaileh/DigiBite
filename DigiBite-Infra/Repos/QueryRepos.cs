using DigiBite_Core.Context;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigiBite_Infra.Repos
{
    public class QueryRepos(DigiBiteContext context) : IQueryRepos
    {

        public async Task<T> GetById<T>(Expression<Func<T, bool>> predicate) where T : class
                  => await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        public IQueryable<TResult> GetProjected<T, TResult>(
            Expression<Func<T, TResult>> resultSelector) where T : class
        => context.Set<T>().Select(resultSelector);


        public IQueryable<TResult> GetProjected<T1, T2, TKey, TResult>(
        Expression<Func<T1, TKey>> outerKeySelector,
        Expression<Func<T2, TKey>> innerKeySelector,
        Expression<Func<T1, T2, TResult>> resultSelector) where T1 : class where T2 : class
        => context.Set<T1>()
                .Join(
                    context.Set<T2>(),
                    outerKeySelector,
                    innerKeySelector,
                    resultSelector
                ).AsQueryable();


        public IQueryable<TResult> GetProjected<T1, T2, T3, TKey, TResult>(
        Expression<Func<T1, TKey>> outerKeySelector,
        Expression<Func<T2, TKey>> innerKeySelector,
        Expression<Func<T3, TKey>> thirdKeySelector,
        Expression<Func<T1, T2, T3, TResult>> resultSelector)
        where T1 : class
        where T2 : class
        where T3 : class
        {
            return context.Set<T1>()
                .Join(
                    context.Set<T2>(),
                    outerKeySelector,
                    innerKeySelector,
                    (t1, t2) => new { t1, t2 })
                .Join(
                    context.Set<T3>(),
                    t => outerKeySelector.Compile()(t.t1),
                    thirdKeySelector,
                    (t, t3) => resultSelector.Compile()(t.t1, t.t2, t3)
                ).AsQueryable();
        }



        public IQueryable<TResult> GetProjected<T1, T2, T3, T4, TKey, TResult>(
        Expression<Func<T1, TKey>> outerKeySelector,
        Expression<Func<T2, TKey>> innerKeySelector,
        Expression<Func<T3, TKey>> thirdKeySelector,
        Expression<Func<T4, TKey>> fourthKeySelector,
        Expression<Func<T1, T2, T3, T4, TResult>> resultSelector)
        where T1 : class
        where T2 : class
        where T3 : class
        where T4 : class
        {
            return context.Set<T1>()
                .Join(
                    context.Set<T2>(),
                    outerKeySelector,
                    innerKeySelector,
                    (t1, t2) => new { t1, t2 })
                .Join(
                    context.Set<T3>(),
                    t => outerKeySelector.Compile()(t.t1),
                    thirdKeySelector,
                    (t, t3) => new { t.t1, t.t2, t3 })
                .Join(
                    context.Set<T4>(),
                    t => outerKeySelector.Compile()(t.t1),
                    fourthKeySelector,
                    (t, t4) => resultSelector.Compile()(t.t1, t.t2, t.t3, t4)
                ).AsQueryable();
        }












    }
}
