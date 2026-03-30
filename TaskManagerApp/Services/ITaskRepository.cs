using TaskManagerApp.Models;

namespace TaskManagerApp.Services;

public interface ITaskRepository
{
    Task<List<TaskItem>> GetAllTasks();
    Task<TaskItem?> GetTaskById(int id);
    Task SaveTask(TaskItem task);
    Task DeleteTask(TaskItem task);
}