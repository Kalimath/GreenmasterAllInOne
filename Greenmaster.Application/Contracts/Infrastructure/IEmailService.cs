using Greenmaster.Domain.Models.Mail;

namespace Greenmaster.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email email);
}