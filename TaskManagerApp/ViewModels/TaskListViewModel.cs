using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp.ViewModels;

public class TaskListViewModel : BaseViewModel
{
    private readonly ITaskRepository repository;

    public ObservableCollection<TaskItem> Tasks { get; set; } = new();

    private TaskItem? selectedTask;
    public TaskItem? SelectedTask
    {
        get => selectedTask;
        set
        {
            SetProperty(ref selectedTask, value);
            if (value != null)
                SelectTaskCommand.Execute(value);
        }
    }

    private bool isLoading;
    public bool IsLoading
    {
        get => isLoading;
        set => SetProperty(ref isLoading, value);
    }

    public ICommand LoadTasksCommand { get; }
    public ICommand SelectTaskCommand { get; }

    public TaskListViewModel(ITaskRepository repo)
    {
        repository = repo;

        LoadTasksCommand = new Command(async () => await LoadTasks());
        SelectTaskCommand = new Command<TaskItem>(async (task) => await OpenTask(task));
    }

    private async Task LoadTasks()
    {
        try
        {
            IsLoading = true;

            Tasks.Clear();
            var tasks = await repository.GetAllTasks();

            foreach (var task in tasks)
                Tasks.Add(task);
        }
        catch
        {
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task OpenTask(TaskItem task)
    {
        if (task == null)
            return;

        await Shell.Current.GoToAsync($"{nameof(TaskDetailPage)}?taskId={task.Id}");
    }
}