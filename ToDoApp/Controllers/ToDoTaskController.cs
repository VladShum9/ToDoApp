using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;

        public ToDoTaskController(IToDoTaskService toDoTaskService)
        {
            _toDoTaskService = toDoTaskService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<OperationResult<ToDoTask>> Add(ToDoTask toDoTask)
        {
            if (toDoTask == null)
            {
                throw new ArgumentNullException(nameof(toDoTask));
            }

            return await _toDoTaskService.Add(toDoTask);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<OperationResult<ToDoTask>> Delete(string id)
        {
            if (!string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            return await _toDoTaskService.Delete(id);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<OperationResult<ToDoTask>> GetById(string id)
        {
            if(!string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            return await _toDoTaskService.GetById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<OperationResult<List<ToDoTask>>> GetAll()
        {
            return await _toDoTaskService.GetAll();
        }

        [HttpPut]
        [Route("Update")]
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
