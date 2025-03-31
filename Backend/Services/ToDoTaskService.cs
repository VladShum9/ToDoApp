using Backend.Interfaces;
using Persistence;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly UnitOfWork _unitOfWork;
        public ToDoTaskService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ToDoTask> Add(ToDoTask task)
        {
            if(task == null) throw new ArgumentNullException(nameof(task));
            ToDoTask result = await _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.SaveChanges();
            return result;
        }

        public Task Delete(string id)
        {
           if(id == null) throw new ArgumentNullException("id is null");
           Task result = _unitOfWork.TaskRepository.Delete(id);
           return result;
        }

        public Task<List<ToDoTask>> GetAll()
        {
            return _unitOfWork.TaskRepository.GetAll();
        }

        public Task<ToDoTask> GetById(string id)
        {
            if(id == null) throw new ArgumentNullException("id is null");
            Task<ToDoTask> task = _unitOfWork.TaskRepository.Get(id);
            return task;
        }

        public async Task Update(ToDoTask task)
        {
            await _unitOfWork.TaskRepository.Update(task);
        }
    }
}
