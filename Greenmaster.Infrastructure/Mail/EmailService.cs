using Greenmaster.Application.Contracts.Infrastructure;
using Greenmaster.Domain.Models.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using static System.Net.HttpStatusCode;

namespace Greenmaster.Infrastructure.Mail;

public class EmailService(IOptions<EmailSettings> emailSettings) : IEmailService
{
    private readonly EmailSettings _emailSettings = emailSettings.Value;

    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        
        var subject = email.Subject;
        var destination = new EmailAddress(email.To);
        var body = email.Body;
        
        var from = new EmailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName);
        
        var msg = MailHelper.CreateSingleEmail(from, destination, subject, body, body);
        var response = await client.SendEmailAsync(msg);

        return response.StatusCode switch
        {
            Accepted or OK => true,
            _ => false
        };
    }
}