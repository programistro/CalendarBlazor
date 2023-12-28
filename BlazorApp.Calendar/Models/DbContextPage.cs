using BlazorApp.Calendar.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Calendar.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Calendar.Models;

public partial class DbContextPage : ComponentBase
{
    [Inject]
    public IDbContextFactory<NorthwindContext> DbFactory { get; set; }

    protected NorthwindContext dbContext;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (dbContext == null)
        {
            dbContext = await DbFactory.CreateDbContextAsync();
            await dbContext.SeedAsync();
        }
    }
}