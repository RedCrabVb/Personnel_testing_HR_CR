using Microsoft.AspNetCore.Identity.UI.Services;

namespace Personnel_testing_HR_CR.Services
{
    public class EmailSender : IEmailSender  
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await Task.CompletedTask;
        }
    }
}
