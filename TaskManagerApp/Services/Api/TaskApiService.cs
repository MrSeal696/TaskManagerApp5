using System.Net.Http.Json;

namespace TaskManagerApp.Services.Api;

public class TaskApiService : ITaskApiService
{
    private readonly HttpClient httpClient;

    public TaskApiService(HttpClient client)
    {
        httpClient = client;
        httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        httpClient.Timeout = TimeSpan.FromSeconds(10);
    }

    public async Task<List<TaskDto>> GetTasks()
    {
        return await Retry(async () =>
        {
            var result = await httpClient.GetFromJsonAsync<List<TaskDto>>("todos");
            return result ?? new List<TaskDto>();
        });
    }

    public async Task<TaskDto?> GetTask(int id)
    {
        return await Retry(async () =>
        {
            return await httpClient.GetFromJsonAsync<TaskDto>($"todos/{id}");
        });
    }

    public async Task<TaskDto?> CreateTask(TaskDto task)
    {
        return await Retry(async () =>
        {
            var response = await httpClient.PostAsJsonAsync("todos", task);
            return await response.Content.ReadFromJsonAsync<TaskDto>();
        });
    }

    public async Task<TaskDto?> UpdateTask(TaskDto task)
    {
        return await Retry(async () =>
        {
            var response = await httpClient.PutAsJsonAsync($"todos/{task.id}", task);
            return await response.Content.ReadFromJsonAsync<TaskDto>();
        });
    }

    public async Task DeleteTask(int id)
    {
        await Retry(async () =>
        {
            await httpClient.DeleteAsync($"todos/{id}");
            return true;
        });
    }

    private async Task<T> Retry<T>(Func<Task<T>> action)
    {
        int retries = 3;

        for (int i = 0; i < retries; i++)
        {
            try
            {
                return await action();
            }
            catch
            {
                if (i == retries - 1)
                    throw;

                await Task.Delay(1000);
            }
        }

        return default!;
    }
}