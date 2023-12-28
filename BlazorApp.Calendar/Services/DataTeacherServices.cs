using BlazorApp.Calendar.Models;

namespace BlazorApp.Calendar.Services;

public class DataTeacherServices
{
    private List<Teacher> data = new();

    public IReadOnlyList<Teacher> GetData() => data;

    public void AddData(Teacher value)
    {
        data.Add(value);
        NotifyDataChanged();
    }

    public event Action OnDataChanged;

    
    
    private void NotifyDataChanged()
    {
        OnDataChanged?.Invoke();
    }
}