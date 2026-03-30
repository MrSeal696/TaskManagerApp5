namespace TaskManagerApp.Services.Api;

public class TaskDto
{
    public int id { get; set; }
    public string title { get; set; } = "";
    public bool completed { get; set; }
}