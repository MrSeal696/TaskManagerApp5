using TaskManagerApp.ViewModels;

namespace TaskManagerApp;

public partial class TaskDetailPage : ContentPage
{
    public TaskDetailPage(TaskDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}