using DigiBite_Core.DTOs.Email;

namespace DigiBite_Core.IServices
{
    public interface IEmailService
    {
        bool SendMail(EmailDTO Mail_Data);
    }
}