using Microsoft.Extensions.DependencyInjection;

namespace Greenmaster.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        
        services.AddAutoMapper(assemblies);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies
            (AppDomain.CurrentDomain.GetAssemblies()));
        
        return services;
    }
}