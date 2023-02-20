using System.Data;
using Hangfire;
using Hangfire.MySql;
using WebApplication6.Config.Core.Contract;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace WebApplication6.Config.Hangfire;

public class Hangfire : IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration)
    {
        var databaseConnection =  configuration.GetConnectionString("hangfire");
        var builder =  service;
        
        
        builder.AddHangfire(x => x.UseStorage(new MySqlStorage(databaseConnection,new MySqlStorageOptions
        {
            TransactionIsolationLevel = (IsolationLevel?)System.Data.IsolationLevel.ReadCommitted,
            QueuePollInterval = TimeSpan.FromSeconds(15),
            JobExpirationCheckInterval = TimeSpan.FromHours(1),
            CountersAggregateInterval = TimeSpan.FromMinutes(5),
            PrepareSchemaIfNecessary = true,
            DashboardJobListLimit = 50000,
            TransactionTimeout = TimeSpan.FromMinutes(1),
            TablesPrefix = "Hangfire"
        })));
        builder.AddHangfireServer();
    }
}