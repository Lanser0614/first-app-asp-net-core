using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.DbContext;

public class DbDatabaseContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbDatabaseContext(DbContextOptions<DbDatabaseContext> options) :
        base(options)
    {
    }
    
    public DbSet<User> users { get; set; }
    public DbSet<Token> tokens { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasOne(u => u.Token)
            .WithOne(p => p.User)
            .HasForeignKey<Token>(p => p.UserKey);
    }
}