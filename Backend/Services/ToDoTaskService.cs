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
        public async Task<OperationResult<ToDoTask>> Add(ToDoTask task)
        {
            if(task == null) throw new ArgumentNullException(nameof(task));
            task.Id = Guid.NewGuid().ToString();
            OperationResult<ToDoTask> result = await _unitOfWork.TaskRepository.Add(task);
            _unitOfWork.SaveChanges();
            return result;
        }

        public async Task<OperationResult<ToDoTask>> Delete(string id)
        {
           if(id == null) throw new ArgumentNullException("id is null");
           OperationResult<ToDoTask> result = await _unitOfWork.TaskRepository.Delete(id);
           return result;
        }

        public async Task<OperationResult<List<ToDoTask>>> GetAll()
        {
            return await _unitOfWork.TaskRepository.GetAll();
        }

        public async Task<OperationResult<ToDoTask>> GetById(string id)
        {
            if(id == null) throw new ArgumentNullException("id is null");
            OperationResult<ToDoTask> task = await _unitOfWork.TaskRepository.Get(id);
            return task;
        }

        public async Task<OperationResult<ToDoTask>> Update(ToDoTask task)
        {
            OperationResult<ToDoTask> operationResult = await _unitOfWork.TaskRepository.Update(task);
            _unitOfWork.SaveChanges();
            return operationResult;
        }
    }
}
