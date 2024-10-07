namespace DigiBite_Core.IRepos
{
    public interface IQueryRepos
    {
        Task<List<T>> GetEntitiesAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
        Task<T> GetEntityAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : class;
    }
}
