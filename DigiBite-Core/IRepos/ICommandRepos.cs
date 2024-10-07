using Microsoft.EntityFrameworkCore.Storage;

namespace DigiBite_Core.IRepos
{
    public interface ICommandRepos
    {
        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> AddRangAsync<T>(IEnumerable<T> entity) where T : class;
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<int> RemovePermanentlyAsync<T>(T entity) where T : class;
        Task<int> RemoveRangPermanentlyAsync<T>(IEnumerable<T> input) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> UpdateRangAsync<T>(IEnumerable<T> entity) where T : class;
    }
}
