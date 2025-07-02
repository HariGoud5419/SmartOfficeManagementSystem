using Microsoft.Extensions.DependencyInjection;
using SmartOffice.Core.Interfaces;
using SmartOffice.Infrastructure.Services;

namespace SmartOffice.Infrastructure.Extensions
{
    /// <summary>
    /// Provides extension methods for registering services and dependencies for the Smart Office system.
    /// Keeps DI setup clean and centralized.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all infrastructure and cross-cutting service dependencies for Smart Office.
        /// </summary>
        /// <param name="services">The IServiceCollection instance to register services with.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddSmartOfficeInfrastructure(this IServiceCollection services)
        {
            // Add HttpContextAccessor for accessing HTTP context (Tenant Id from headers)
            services.AddHttpContextAccessor();

            // Tenant-related services
            services.AddScoped<ITenantProvider, TenantProvider>();
            // services.AddScoped<ITenantService, TenantService>();

            // Repository and Unit of Work (Register later when created)
            // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            // services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Optional: Add other services like caching, logging, etc.

            return services;
        }
    }
}
