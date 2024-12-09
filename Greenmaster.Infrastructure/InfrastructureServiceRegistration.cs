using Greenmaster.Application.Contracts.Infrastructure;
using Greenmaster.Domain.Models.Mail;
using Greenmaster.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Greenmaster.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        
        services.AddTransient<IEmailService, EmailService>();
        
        return services;
    }
}