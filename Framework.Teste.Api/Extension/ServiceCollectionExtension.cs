using Framework.Teste.Service.Interfaces;
using Framework.Teste.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;

namespace Framework.Teste.Api.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.TryAddScoped<IDecomposeService, DecomposeService>();
            return services;
        }
        
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Framework.Teste.Api", Version = "v1"});
            });
            return services;
        }
    }
}