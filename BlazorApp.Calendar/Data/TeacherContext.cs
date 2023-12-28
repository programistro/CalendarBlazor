using Microsoft.EntityFrameworkCore;
using BlazorApp.Calendar.Models;
using Microsoft.Data.Sqlite;


namespace BlazorApp.Calendar.Data;

public class TeacherContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public TeacherContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=database.db");
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