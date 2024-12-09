using Greenmaster.Application;
using Greenmaster.Infrastructure;
using Greenmaster.Persistence;
using Microsoft.EntityFrameworkCore;

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

        builder.Services.AddSwaggerGen();
        
        return builder.Build();
    }

    /// <summary>
    /// Configure middleware registrations
    /// </summary>
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.MapControllers();
        
        return app;
    }

    /// <summary>
    /// Resets database when application starts
    /// </summary>
    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BotanicalDbContext>();
            if (dbContext is not null)
            {
                await dbContext.Database.EnsureDeletedAsync();
                await dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}