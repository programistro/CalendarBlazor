using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Calendar.Models;

public class UsersRegister
{
    // [Key]
    // public int Id { get; set; }
    
    public string UserName { get; set; }
    
    [Key]
    public string Email { get; set; }
    
    public string Password { get; set; }
}
