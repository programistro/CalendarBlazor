using Microsoft.EntityFrameworkCore;
using BlazorApp.Calendar.Models;
using Microsoft.Data.Sqlite;


namespace BlazorApp.Calendar.Data;

public class AppointmentContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Appointment>  Appointments => Set<Appointment>();
    public AppointmentContext() => Database.EnsureCreated();
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Appoinment_Database.db");
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