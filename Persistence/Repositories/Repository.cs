﻿using Persistence.Interfaces;
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

        public async Task Delete(string id)
        {
            T existing = await Get(id);
            _dbSet.Remove(existing);
        }

        public async Task<T> Get(string id)
        {
            T result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<List<T>> GetAll()
        {
            List<T> result = _dbSet.ToList();
            return result;
        }

        public Task Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
