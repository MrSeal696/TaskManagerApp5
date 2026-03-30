using Microsoft.Extensions.Logging;
using TaskManagerApp.Services;
using TaskManagerApp.Services.Api;
using TaskManagerApp.ViewModels;

namespace TaskManagerApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<ITaskApiService, TaskApiService>();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db");

        builder.Services.AddSingleton<ITaskRepository>(s =>
        {
            var local = new TaskRepository(dbPath);
            var api = s.GetRequiredService<ITaskApiService>();
            return new SyncTaskRepository(local, api);
        });

        builder.Services.AddTransient<TaskListViewModel>();
        builder.Services.AddTransient<TaskDetailViewModel>();
        builder.Services.AddTransient<TaskListPage>();
        builder.Services.AddTransient<TaskDetailPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}