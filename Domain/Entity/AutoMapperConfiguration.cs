using AutoMapper;
using CustomerPanel.Domain.Entity.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerPanel.Domain.Entity
{
    public static class AutoMapperConfiguration
    {
        public static void AddAutoMapperConfiguration (this IServiceCollection services)
        {
            var config = new MapperConfiguration(add =>
            {
                add.AddProfile<ClientMapper>();
                add.AddProfile<TelephoneMapper>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}