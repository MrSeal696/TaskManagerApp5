using TaskManagerApp.Services.Api;

namespace TaskManagerApp.Services.Api;

public interface ITaskApiService
{
    Task<List<TaskDto>> GetTasks();
    Task<TaskDto?> GetTask(int id);
    Task<TaskDto?> CreateTask(TaskDto task);
    Task<TaskDto?> UpdateTask(TaskDto task);
    Task DeleteTask(int id);
}