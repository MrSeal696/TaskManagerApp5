using TaskManagerApp.ViewModels;

namespace TaskManagerApp;

public partial class TaskListPage : ContentPage
{
    public TaskListPage(TaskListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}