using Greenmaster.Application.Contracts.Persistence;
using Greenmaster.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Greenmaster.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BotanicalDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("GreenmasterBotanicalConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IBloomRepository, BloomRepository>();
        services.AddScoped<ISymbioticRelationRepository, SymbioticRelationRepository>();

        return services;
    }
}