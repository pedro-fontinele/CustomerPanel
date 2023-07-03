using FluentValidation;
using CustomerPanel.Domain.Entity.Dto;
using FluentValidation.AspNetCore;
using CustomerPanel.Domain.Entity.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerPanel.Domain.Entity
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidationConfiguration (this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddScoped<IValidator<ClientDtoAction>, ClientValidator>();
            services.AddScoped<IValidator<TelephoneDtoAction>, TelephoneValidator>();
        }
    }
}