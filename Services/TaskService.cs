using Microsoft.EntityFrameworkCore;
using softone_task_management_backend.Domains.Dtos;
using softone_task_management_backend.Domains.Entities;
using softone_task_management_backend.Services.Interfaces;

namespace softone_task_management_backend.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _applicableDbContext;

        public TaskService(ApplicationDbContext applicableDbContext)
        {
            this._applicableDbContext = applicableDbContext;
        }

        public async Task<TaskDto> CreateTask(TaskDto tasks)
        {
            try
            {
                var task = new Tasks
                {
                    UserId = tasks.UserId,
                    Title = tasks.Title,
                    Description = tasks.Description,
                    IsChecked = tasks.IsChecked,
                };

                this._applicableDbContext.Add(task);
                await this._applicableDbContext.SaveChangesAsync();

                return new TaskDto
                {
                    Id = task.Id, // The ID assigned by the database
                    UserId = task.UserId,
                    Title = task.Title,
                    Description = task.Description,
                    IsChecked = task.IsChecked,
                };
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Error occured in creating task");
            }
        }

        public async Task<List<TaskDto>> GetTaskList(Guid userId)
        {
            try
            {
                var tasks = await this._applicableDbContext.Tasks.Where(t => t.UserId == userId).ToListAsync();

                var taskList = tasks.Select(t => new TaskDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Title = t.Title,
                    Description = t.Description,
                    IsChecked = t.IsChecked,
                }).ToList();

                return taskList;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Error occured in getting task list");
            }
        }

        public async Task UpdateTask(TaskDto tasks)
        {
            try
            {
                var existingTask = await this._applicableDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == tasks.Id);

                if (existingTask is not null)
                {
                    existingTask.Title = tasks.Title;
                    existingTask.Description = tasks.Description;
                    existingTask.IsChecked = tasks.IsChecked;
                }
                
                this._applicableDbContext.Update(existingTask);
                await this._applicableDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Error occured in updating task");
            }
        }

        public async Task RemoveTask(Guid id)
        {
            try
            {
                var existingTask = await this._applicableDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

                if (existingTask is not null)
                {
                    this._applicableDbContext.Remove(existingTask);
                }

                await this._applicableDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Error occured in updating task");
            }
        }
    }
}
