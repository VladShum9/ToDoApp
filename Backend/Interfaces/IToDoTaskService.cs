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
        public Task<OperationResult<ToDoTask>> Add(ToDoTask task);
        public Task<OperationResult<ToDoTask>> Delete(string id);
        public Task<OperationResult<ToDoTask>> Update(ToDoTask task);
        public Task<OperationResult<List<ToDoTask>>> GetAll();
        public Task<OperationResult<ToDoTask>> GetById(string id);
    }
}
