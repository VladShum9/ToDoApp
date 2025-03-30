﻿using Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
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

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
