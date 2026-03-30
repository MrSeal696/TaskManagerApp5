using TaskManagerApp.Models;
using TaskManagerApp.Services.Api;

namespace TaskManagerApp.Services;

public class SyncTaskRepository : ITaskRepository
{
    private readonly ITaskRepository localRepo;
    private readonly ITaskApiService api;

    public SyncTaskRepository(ITaskRepository local, ITaskApiService apiService)
    {
        localRepo = local;
        api = apiService;
    }

    public async Task<List<TaskItem>> GetAllTasks()
    {
        try
        {
            var apiTasks = await api.GetTasks();

            var result = apiTasks.Select(t => new TaskItem
            {
                Id = t.id,
                Title = t.title,
                IsCompleted = t.completed,
                Description = "",
                DueDate = DateTime.Now,
                Priority = 1
            }).ToList();

            foreach (var task in result)
                await localRepo.SaveTask(task);

            return result;
        }
        catch
        {
            return await localRepo.GetAllTasks();
        }
    }

    public async Task<TaskItem?> GetTaskById(int id)
    {
        try
        {
            var dto = await api.GetTask(id);
            if (dto == null) return null;

            return new TaskItem
            {
                Id = dto.id,
                Title = dto.title,
                IsCompleted = dto.completed,
                Description = "",
                DueDate = DateTime.Now,
                Priority = 1
            };
        }
        catch
        {
            return await localRepo.GetTaskById(id);
        }
    }

    public async Task SaveTask(TaskItem task)
    {
        try
        {
            var dto = new TaskDto
            {
                id = task.Id,
                title = task.Title,
                completed = task.IsCompleted
            };

            if (task.Id == 0)
                await api.CreateTask(dto);
            else
                await api.UpdateTask(dto);
        }
        catch
        {
        }

        await localRepo.SaveTask(task);
    }

    public async Task DeleteTask(TaskItem task)
    {
        try
        {
            await api.DeleteTask(task.Id);
        }
        catch
        {
        }

        await localRepo.DeleteTask(task);
    }
}