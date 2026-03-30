using System.Windows.Input;
using TaskManagerApp.Models;
using TaskManagerApp.Services;

namespace TaskManagerApp.ViewModels;

[QueryProperty(nameof(TaskId), "taskId")]
public class TaskDetailViewModel : BaseViewModel
{
    private readonly ITaskRepository repository;

    private TaskItem currentTask = new TaskItem();
    public TaskItem CurrentTask
    {
        get => currentTask;
        set => SetProperty(ref currentTask, value);
    }

    private int taskId;
    public int TaskId
    {
        get => taskId;
        set
        {
            taskId = value;
            LoadTask(value);
        }
    }

    public ICommand ToggleCompletedCommand { get; }
    public ICommand SaveCommand { get; }
    public ICommand DeleteCommand { get; }

    public TaskDetailViewModel(ITaskRepository repo)
    {
        repository = repo;

        ToggleCompletedCommand = new Command(() =>
        {
            CurrentTask.IsCompleted = !CurrentTask.IsCompleted;
            OnPropertyChanged(nameof(CurrentTask));
        });

        SaveCommand = new Command(async () => await SaveTask());
        DeleteCommand = new Command(async () => await DeleteTask());
    }

    private async void LoadTask(int id)
    {
        try
        {
            var task = await repository.GetTaskById(id);

            if (task != null)
                CurrentTask = task;
        }
        catch
        {

        }
    }

    private async Task SaveTask()
    {
        try
        {
            await repository.SaveTask(CurrentTask);
        }
        catch
        {

        }
    }

    private async Task DeleteTask()
    {
        try
        {
            await repository.DeleteTask(CurrentTask);
            await Shell.Current.GoToAsync("..");
        }
        catch
        {

        }
    }
}