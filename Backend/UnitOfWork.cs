using Persistence;
using Persistence.Interfaces;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    class UnitOfWork
    {
        private readonly ToDoAppDbContext _dbContext;

        private readonly IRepository<ToDoTask> _taskRepository;

        UnitOfWork(ToDoAppDbContext dbContext, IRepository<ToDoTask> taskRepository)
        {
            _dbContext = dbContext;
            _taskRepository = taskRepository;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
