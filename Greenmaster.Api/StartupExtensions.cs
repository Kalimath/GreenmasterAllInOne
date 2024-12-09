using Greenmaster.Application;
using Greenmaster.Infrastructure;
using Greenmaster.Persistence;

namespace Greenmaster.Api;

public static class StartupExtensions
{
    /// <summary>
    /// Configure service registrations
    /// </summary>
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        
        builder.Services.AddControllers();

        builder.Services.AddCors(options => options.AddPolicy(
            "open",
            policy => policy.WithOrigins(
                    builder.Configuration["ApiUrl"] ?? "https://localhost:7020", 
                    builder.Configuration["ClientUrl"] ?? "https://localhost:7080")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));
        
        return builder.Build();
    }

    /// <summary>
    /// Configure middleware registrations
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        app.UseHttpsRedirection();
        app.MapControllers();
        
        return app;
    }
}