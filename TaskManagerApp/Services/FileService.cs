using System.Text;
using TaskManagerApp.Models;

namespace TaskManagerApp.Services;

public class FileService
{
    private string filePath = Path.Combine(FileSystem.AppDataDirectory, "tasks.csv");

    public async Task Export(List<TaskItem> tasks)
    {
        var sb = new StringBuilder();

        foreach (var t in tasks)
        {
            sb.AppendLine($"{t.Id},{t.Title},{t.Description},{t.DueDate},{t.IsCompleted},{t.Priority}");
        }

        File.WriteAllText(filePath, sb.ToString());
    }

    public List<TaskItem> Import()
    {
        var tasks = new List<TaskItem>();

        if (!File.Exists(filePath))
            return tasks;

        var lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            var parts = line.Split(',');

            tasks.Add(new TaskItem
            {
                Id = int.Parse(parts[0]),
                Title = parts[1],
                Description = parts[2],
                DueDate = DateTime.Parse(parts[3]),
                IsCompleted = bool.Parse(parts[4]),
                Priority = int.Parse(parts[5])
            });
        }

        return tasks;
    }
}