using Microsoft.AspNetCore.Mvc;
using softone_task_management_backend.Domains.Dtos;
using softone_task_management_backend.Services.Interfaces;

namespace softone_task_management_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        [HttpPost]
        public async Task<TaskDto> CreateTask(TaskDto task)
        {
            return await this._taskService.CreateTask(task);
        }

        [HttpGet("{userId}")]
        public async Task<List<TaskDto>> GetTaskListByUser(Guid userId)
        {
            return await this._taskService.GetTaskList(userId);
        }

        [HttpPatch]
        public async Task UpdateTask(TaskDto task)
        {
            await this._taskService.UpdateTask(task);
        }

        [HttpDelete("{id}")]
        public async Task RemoveTask(Guid id)
        {
            await this._taskService.RemoveTask(id);
        }
    }
}
