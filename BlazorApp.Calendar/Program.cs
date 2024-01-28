using BlazorApp.Calendar.Data;
using BlazorApp.Calendar.Models;
using BlazorApp.Calendar.Provider;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Calendar.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

//using ElectronNET.API;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddCookie(opt =>
{
    opt.Cookie.Name = "TryingoutGoogleOAuth";
    opt.LoginPath = "/auth/google-singin";
})
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});

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
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication().AddIdentityCookies();
builder.Services.AddMemoryCache();
builder.Services.AddDbContextFactory<NorthwindContext>();
builder.Services.AddDbContextFactory<UserRegistersContext>();
builder.Services.AddDbContextFactory<TeacherContext>();
builder.Services.AddDbContextFactory<ClientContext>();
builder.Services.AddDbContextFactory<AppointmentContext>();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
//                .AddEntityFrameworkStores<AuthDBContext>()
//                .AddDefaultTokenProviders();


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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");
});

await app.RunAsync();