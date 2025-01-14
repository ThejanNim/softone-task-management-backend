using softone_task_management_backend.Domains.Dtos;

namespace softone_task_management_backend.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> CreateTask(TaskDto tasks);

        Task<List<TaskDto>> GetTaskList(Guid userId);

        Task UpdateTask(TaskDto tasks);

        Task RemoveTask(Guid id);
    }
}
