using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Http.Requests.User;

public class User
{
    [Required, MaxLength(15)]
    public string Name { get; set; }
    
    [Required, MinLength(8)]
    public string Password { get; set; }
    
    [Required, EmailAddress]
    public string? Email { get; set; }
}