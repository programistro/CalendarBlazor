using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Calendar.Models;

public class Client
{
    [Key]
    public string Name { get; set; }

    public string SurName { get; set; }

    public string MidleName { get; set; }
    
    public string Photo { get; set; }
}