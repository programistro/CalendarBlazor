using BlazorApp.Calendar.Models;

namespace BlazorApp.Calendar.Services;

public class DataUpdateService
{
    public event Action<Teacher> DataUpdated;

    public void UpdateData(Teacher data)
    {
        DataUpdated?.Invoke(data);
    }
}
