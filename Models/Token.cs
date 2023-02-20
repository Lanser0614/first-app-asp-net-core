using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models;

public class Token
{
    public int Id { get; set; }
    public string? token { get; set; }
    public string? RefreshToken { get; set; }

    [ForeignKey("user_id_key")]
    public int UserKey { get; set; }
    public User User { get; set; }

}