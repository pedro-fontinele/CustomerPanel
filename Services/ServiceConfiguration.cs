using Microsoft.Extensions.DependencyInjection;

namespace CustomerPanel.Services
{
    public static class ServiceConfiguration
    {
        public static void AddServiceConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IClientService, ClientService>();
        }
    }
}
