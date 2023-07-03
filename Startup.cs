using CustomerPanel.Data.Context;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CustomerPanel.Services;
using CustomerPanel.Persistence.Repository;
using CustomerPanel.Domain.Entity;

namespace CustomerPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Context
            services.AddDbContext<DataContext>(context => context.UseSqlite(Configuration.GetConnectionString("SQLite")));
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerPanel", Version = "v1" });
            });
            #endregion

            #region Controller
            services.AddControllers();
            #endregion

            #region Service
            services.AddServiceConfiguration();
            #endregion

            #region Repository
            services.AddRepositoryConfiguration();
            #endregion

            #region FluentValidation
            services.AddFluentValidationConfiguration();
            #endregion

            #region AutoMapper
            services.AddAutoMapperConfiguration();
            #endregion

            #region ApiVersioning
            services.AddApiVersioning();
            #endregion

            #region Cors
            services.AddCors();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerPanel v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
