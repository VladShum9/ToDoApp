using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;

namespace ToDoApp.Controllers
{
    [Route("api/toDoTasks")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTaskController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        [HttpPost]
        public async Task<OperationResult<ToDoTask>> Add(ToDoTask toDoTask)
        {
            if (toDoTask == null)
            {
                throw new ArgumentNullException(nameof(toDoTask));
            }

            return await _toDoTaskService.Add(toDoTask);
        }

        [HttpDelete("{id}")]
        public async Task<OperationResult<ToDoTask>> Delete(string id)
        {
            if (!string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            return await _toDoTaskService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<OperationResult<ToDoTask>> GetById(string id)
        {
            if(!string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            return await _toDoTaskService.GetById(id);
        }

        [HttpGet]
        public async Task<OperationResult<List<ToDoTask>>> GetAll()
        {
            return await _toDoTaskService.GetAll();
        }

        [HttpPut]
        public async Task<OperationResult<ToDoTask>> Update(ToDoTask toDoTask)
        {
            if(toDoTask == null)
            {
                throw new ArgumentNullException(nameof(toDoTask));
            }
            
            return await _toDoTaskService.Update(toDoTask);
        }
    }
}
