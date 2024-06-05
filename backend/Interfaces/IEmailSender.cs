using backend.Dtos.Email;

namespace backend.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(SendEmailDto emailModel);
    }
}
