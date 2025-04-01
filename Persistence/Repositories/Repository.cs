using Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ToDoAppDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ToDoAppDbContext dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<OperationResult<T>> Add(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                return OperationResult<T>.SuccessResult(entity, "Entity added successfully");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Failure($"Error adding entity {ex.Message}");
            }
        }

        public async Task<OperationResult<T>> Delete(string id)
        {
            try
            {
                OperationResult<T> existing = await Get(id);
                _dbSet.Remove(existing.Data);
                return OperationResult<T>.SuccessResult(existing.Data, "Enity was deleted successfully" );
            }
            catch (Exception ex) {
                return OperationResult<T>.Failure($"Error adding entity {ex.Message}");
            }
        }

        public async Task<OperationResult<T>> Get(string id)
        {
            try
            {
                T result = await _dbSet.FindAsync(id);
                return OperationResult<T>.SuccessResult(result, "Entity was found successfully");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Failure($"Error finding entity {ex.Message}");
            }
        }

        public async Task<OperationResult<List<T>>> GetAll()
        {
            try
            {
                List<T> result = _dbSet.ToList();
                return OperationResult<List<T>>.SuccessResult(result, "List of all entities was found successfully");
            }
            catch (Exception ex)
            {
                return OperationResult<List<T>>.Failure($"Errror getting list of all entities {ex.Message}");
            }
        }

        public async Task<OperationResult<T>> Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                return OperationResult<T>.SuccessResult(entity, "Entity was updated successfuly");
            }
            catch (Exception ex)
            {
                return OperationResult<T>.Failure($"Error updating entity {ex.Message}");
            }
        }
    }
}
