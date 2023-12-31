using BlazorApp.Calendar.Data;
using BlazorApp.Calendar.Models;
using BlazorApp.Calendar.Services;
//using ElectronNET.API;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<NorthwindService>();
builder.Services.AddScoped<NorthwindODataService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<DataTeacherServices>();
builder.Services.AddScoped<DataUpdateService>();
builder.Services.AddMemoryCache();
builder.Services.AddDbContextFactory<NorthwindContext>();
builder.Services.AddDbContextFactory<TeacherContext>();
builder.Services.AddDbContextFactory<ClientContext>();
builder.Services.AddDbContextFactory<AppointmentContext>();
builder.Services.AddSignalR(e => {
    e.MaximumReceiveMessageSize = 102400000;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();