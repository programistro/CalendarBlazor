using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Calendar.Models;

public class Teacher
{ 
    [Key]
    public string Name { get; set; }
    public string Post { get; set; }
    
    public string PathToPhoto { get; set; }
    // [Key]
    // public string Phone { get; set; }
    // [Key]
    // public string Adress { get; set; }
}