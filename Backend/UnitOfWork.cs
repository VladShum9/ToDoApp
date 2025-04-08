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
    public class UnitOfWork
    {
        private readonly ToDoAppDbContext _dbContext;

        public readonly IRepository<ApplicationUser> UserRepository;
        public readonly IRepository<ToDoTask> TaskRepository;

        public UnitOfWork(ToDoAppDbContext dbContext, IRepository<ToDoTask> taskRepository, IRepository<ApplicationUser> userRepository)
        {
            _dbContext = dbContext;
            TaskRepository = taskRepository;
            UserRepository = userRepository;
        }

        public async void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
