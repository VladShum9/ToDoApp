using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IToDoTaskService
    {
        public Task<ToDoTask> Add(ToDoTask task);
        public Task Delete(string id);
        public Task Update(ToDoTask task);
        public Task<List<ToDoTask>> GetAll();
        public Task<ToDoTask> GetById(string id);
    }
}
