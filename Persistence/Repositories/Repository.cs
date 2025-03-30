﻿using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly ToDoAppDbContext _dbContext;
        public Repository(ToDoAppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task Delete(string id)
        {
            T existing = await Get(id);
            _dbContext.Remove(existing);
        }

        public async Task<T> Get(string id)
        {
            throw new NotImplementedException();
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
