using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
    
    [Required, EmailAddress]
    public string? Email { get; set; }
    
    public Token? Token { get; set; }
}