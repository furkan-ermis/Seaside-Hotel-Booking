using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace DestinyHaven.GenericModels
{
    public class SendMail
    {
        private readonly string _mailFrom;
        private readonly string _mailPassword;
        private readonly string _mailTo;
        private readonly string _Admin_UserName;
        private readonly string _User_UserName;
        private readonly string _message;
        private readonly string _subject;

        public SendMail(IConfiguration configuration, string mailTo, string? Admin_UserName, string? User_UserName, string? subject, string? message)
        {
            _mailTo = mailTo;
            _mailFrom = configuration["EmailConfiguration:MailFrom"];
            _mailPassword = configuration["EmailConfiguration:MailPassword"];
            _Admin_UserName = Admin_UserName;
            _User_UserName = User_UserName;
            _message = message;
            _subject = subject;

            Task.Run(async () => await SendMailAsync());
        }

        private async Task SendMailAsync()
        {
            using (SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync(_mailFrom, _mailPassword);

                await client.SendAsync(await CreateMailAsync());

                await client.DisconnectAsync(true);
            }
        }

        private async Task<MimeMessage> CreateMailAsync()
        {
            BodyBuilder bodyBuilder = new BodyBuilder();
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAdressFrom = new MailboxAddress(_Admin_UserName, _mailFrom);
            MailboxAddress mailboxAdressTo = new MailboxAddress(_User_UserName, _mailTo);
            mimeMessage.From.Add(mailboxAdressFrom);
            mimeMessage.To.Add(mailboxAdressTo);
            bodyBuilder.TextBody = _message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = _subject;
            return mimeMessage;
        }
    }
}