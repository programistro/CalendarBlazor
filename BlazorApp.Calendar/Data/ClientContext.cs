using Microsoft.EntityFrameworkCore;
using BlazorApp.Calendar.Models;
using Microsoft.Data.Sqlite;


namespace BlazorApp.Calendar.Data;

public class ClientContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public ClientContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ClientDatabase.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Teacher>().HasData(
        //     new Teacher { Name = "Tom" },
        //     new Teacher { Name = "Bob" },
        //     new Teacher { Name = "Sam" }
        // );
    }
}