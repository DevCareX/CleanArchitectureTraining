using Ticket.Application.Models.Mail;

namespace Ticket.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
