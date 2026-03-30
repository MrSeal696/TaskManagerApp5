using SQLite;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services;

public class TaskRepository : ITaskRepository
{
    private readonly SQLiteAsyncConnection database;

    public TaskRepository(string dbPath)
    {
        database = new SQLiteAsyncConnection(dbPath);
        database.CreateTableAsync<TaskItem>().Wait();
    }

    public async Task<List<TaskItem>> GetAllTasks()
    {
        return await database.Table<TaskItem>().ToListAsync();
    }

    public async Task<TaskItem?> GetTaskById(int id)
    {
        return await database.Table<TaskItem>()
            .Where(t => t.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task SaveTask(TaskItem task)
    {
        if (task.Id != 0)
            await database.UpdateAsync(task);
        else
            await database.InsertAsync(task);
    }

    public async Task DeleteTask(TaskItem task)
    {
        await database.DeleteAsync(task);
    }
}