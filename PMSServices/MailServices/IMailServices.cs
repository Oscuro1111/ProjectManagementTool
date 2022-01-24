using System.Threading.Tasks;

using MaleServices.Model;

namespace MaleServices.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}