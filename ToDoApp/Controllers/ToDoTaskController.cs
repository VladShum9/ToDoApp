using AutoMapper;
using Backend.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Persistence.Models;
using ToDoApp.Viewmodels;

namespace ToDoApp.Controllers
{
    [Route("api/toDoTasks")]
    [ApiController]
    public class ToDoTaskController : ControllerBase
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public ToDoTaskController(IToDoTaskService toDoTaskService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _toDoTaskService = toDoTaskService;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<OperationResult<ToDoTask>> Add(ToDoTaskModel model)
        {
            var user = await _userManager.FindByIdAsync(model.ApplicationUserId);
            if (user == null)
            {
                return OperationResult<ToDoTask>.Failure("User does not exist.");
            }
            ToDoTask toDoTask = _mapper.Map<ToDoTask>(model);
            return await _toDoTaskService.Add(toDoTask);
        }

        [HttpDelete("{id}")]
        public async Task<OperationResult<ToDoTask>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            return await _toDoTaskService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<OperationResult<ToDoTask>> GetById(string id)
        {
            if(string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            return await _toDoTaskService.GetById(id);
        }

        [HttpGet]
        public async Task<OperationResult<List<ToDoTask>>> GetAll()
        {
            return await _toDoTaskService.GetAll();
        }

        [HttpPut]
        public async Task<OperationResult<ToDoTask>> Update(ToDoTaskModel model)
        {
            var user = await _userManager.FindByIdAsync(model.ApplicationUserId);
            if (user == null)
            {
                return OperationResult<ToDoTask>.Failure("User does not exist.");
            }
            ToDoTask toDoTask = _mapper.Map<ToDoTask>(model);

            return await _toDoTaskService.Update(toDoTask);
        }
    }
}
