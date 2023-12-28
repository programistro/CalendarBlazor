using Microsoft.AspNetCore.Components;

namespace BlazorApp.Calendar.Pages;

public partial class CardVariants_razor : ComponentBase
{
    public string Message { get; set; }
    protected override void OnInitialized()
    {
        Message = "Hello, Blazor!";
        StateHasChanged();
    }

    public void UpdateMessage()
    {
        Message = "Updated message";
        StateHasChanged();
    }
}