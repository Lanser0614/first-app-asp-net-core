namespace WebApplication6.Config.Core.Contract;

public interface IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration);
}