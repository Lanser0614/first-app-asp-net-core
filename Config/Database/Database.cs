using Microsoft.EntityFrameworkCore;
using WebApplication6.Config.Core.Contract;
using WebApplication6.DbContext;

namespace WebApplication6.Config.Database;

public class Database : IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("auth");
        service.AddDbContext<DbDatabaseContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
}