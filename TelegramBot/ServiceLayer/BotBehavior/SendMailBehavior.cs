using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
//using System.Net.Mail;
using ServiceLayer.Loggers;
using DataLayer.Users.ClientModels;
using ServiceLayer.BotBehavior.Abstract;
using MimeKit;
using MailKit.Net.Smtp;

namespace ServiceLayer.BotBehavior
{
    public class SendMailBehavior : IBehavior<IClientChat>
    {
        public IBehavior<IClientChat> NextBehavior { get; }

        public SendMailBehavior(IBehavior<IClientChat> nextBehavior = null)
        {
            this.NextBehavior = nextBehavior;
        }

        public void ExecuteBehavior(IClientChat clientChat)
        {
            try
            {
                Task.Factory.StartNew(()=> SendMail(clientChat));
            }
            catch (Exception e)
            {
                LoggerService.SetMassage(e.GetBaseException().Message, new ConsoelLogger());
            }

            NextBehavior?.ExecuteBehavior(clientChat);
        }

        private static void SendMail(IClientChat clientChat)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("MBA_Bot", "wederkar@gмail.com"));
            message.To.Add(new MailboxAddress("AdminBox", "deusvecumest@gmail.com"));
            message.Subject = "Нова регістрація!";
            message.Body = new BodyBuilder()
            {
                HtmlBody = $"<div style=\"color: green;\">Ура, новий клієнт!!!: " +
            $"{"<br> Iм'я: " + clientChat.User.FirstName}; " +
            $"{"<br> Фамілія: " + clientChat.User.LastName}; " +
            $"{"<br> Компанія: " + clientChat.User.Company}; " +
            $"{"<br> Позиція: " + clientChat.User.Position}; " +
            $"{"<br> Чи був раніше?: " + clientChat.User.MemberBefore}; " +
            $"{"<br> Дата регістрації: " + clientChat.User.RigistrationDate}.</div>"
            }.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, true); // use port 465 or 587
                client.Authenticate("wederkar", "sauda0sakdpj23u9djas"); //login-password from the account
                client.Send(message);

                client.Disconnect(true);

                LoggerService.SetMassage("Message sent successfully!", new ConsoelLogger());
            }
        }
    }
}