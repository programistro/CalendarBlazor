using BlazorApp.Calendar.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Calendar.Data;

public class UserRegistersContext : DbContext
{
    public DbSet<UsersRegister> Users => Set<UsersRegister>();
    public UserRegistersContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=users.db");
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