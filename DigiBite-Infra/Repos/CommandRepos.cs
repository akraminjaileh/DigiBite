using DigiBite_Core.Context;
using DigiBite_Core.IRepos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Transactions;

namespace DigiBite_Infra.Repos
{
    public class CommandRepos(DigiBiteContext context) : ICommandRepos
    {

        public async Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                context.Set<T>().Add(entity);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                //Concurrency issues
                throw new Exception($"Concurrency conflict occurred while adding {typeof(T).Name}: {concurrencyEx.Message}", concurrencyEx);
            }
            catch (DbUpdateException dbEx)
            {
                // Constraint Exception
                throw new Exception($"Database error occurred while adding {typeof(T).Name}: {dbEx.Message}", dbEx);
            }

            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"An unexpected error occurred while adding {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<int> AddRangAsync<T>(IEnumerable<T> entity) where T : class
        {

            try
            {
                context.Set<T>().AddRange(entity);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                //Concurrency issues
                throw new Exception($"Concurrency conflict occurred while adding {typeof(T).Name}: {concurrencyEx.Message}", concurrencyEx);
            }
            catch (DbUpdateException dbEx)
            {
                // Constraint Exception
                throw new Exception($"Database error occurred while adding {typeof(T).Name}: {dbEx.Message}", dbEx);
            }

            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"An unexpected error occurred while adding {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {

            try
            {

                context.Set<T>().Update(entity);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                //Concurrency issues
                throw new Exception($"Concurrency conflict occurred while updating {typeof(T).Name}: {concurrencyEx.Message}", concurrencyEx);
            }
            catch (DbUpdateException dbEx)
            {
                // Constraint Exception
                throw new Exception($"Database error occurred while updating {typeof(T).Name}: {dbEx.Message}", dbEx);
            }

            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"An unexpected error occurred while updating {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<int> UpdateRangAsync<T>(IEnumerable<T> entity) where T : class
        {

            try
            {

                context.Set<T>().UpdateRange(entity);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                //Concurrency issues
                throw new Exception($"Concurrency conflict occurred while updating {typeof(T).Name}: {concurrencyEx.Message}", concurrencyEx);
            }
            catch (DbUpdateException dbEx)
            {
                // Constraint Exception
                throw new Exception($"Database error occurred while updating {typeof(T).Name}: {dbEx.Message}", dbEx);
            }

            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"An unexpected error occurred while updating {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<int> RemovePermanentlyAsync<T>(T entity) where T : class
        {

            try
            {

                context.Set<T>().Remove(entity);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                //Concurrency issues
                throw new Exception($"Concurrency conflict occurred while removing {typeof(T).Name}: {concurrencyEx.Message}", concurrencyEx);
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"An unexpected error occurred while removing {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<int> RemoveRangPermanentlyAsync<T>(IEnumerable<T> input) where T : class
        {

            try
            {
              
                context.Set<T>().RemoveRange(input);
                return await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException concurrencyEx)
            {
                //Concurrency issues
                throw new Exception($"Concurrency conflict occurred while removing {typeof(T).Name}: {concurrencyEx.Message}", concurrencyEx);
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"An unexpected error occurred while removing {typeof(T).Name}: {ex.Message}", ex);
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
            => await context.Database.BeginTransactionAsync();
        


    }
}
