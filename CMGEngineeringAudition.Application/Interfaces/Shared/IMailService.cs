using CMGEngineeringAudition.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace CMGEngineeringAudition.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}
