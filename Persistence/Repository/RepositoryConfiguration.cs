using Microsoft.Extensions.DependencyInjection;

namespace CustomerPanel.Persistence.Repository
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositoryConfiguration(this IServiceCollection service)
        {
            service.AddTransient<IClientRepository, ClientRepository>();
        }
    }
}
