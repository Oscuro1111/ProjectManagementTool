using System.Threading.Tasks;
using MaleServices.Model;
using Mailjet.Client;
using Microsoft.Extensions.Configuration;
using Mailjet.Client.TransactionalEmails;

namespace MaleServices.Services
{

    public class MailService : IMailService
    {
        private string privatekey;
        private string publickey;

        public MailService(IConfiguration token)
        {
            this.publickey = token.GetSection("Token:Public").Value;
            this.privatekey = token.GetSection("Token:Private").Value;

        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            MailjetClient _client = new MailjetClient(publickey, privatekey);


            var email = new TransactionalEmailBuilder()
               .WithFrom(new SendContact("kernel-panic-11@yandex.com"))
               .WithSubject("Ginilytics IT Solution Verification Code.")
               .WithHtmlPart(mailRequest.Body)
               .WithTo(new SendContact(mailRequest.ToEmail))
               .Build();

            // invoke API to send email
            var response = await _client.SendTransactionalEmailAsync(email);
        }
        
    }
}

/*
  //MailjetRequest request = new MailjetRequest
            //{
            //    Resource = Send.Resource,
            //}
            //   .Property(Send.Messages, new JArray {
            //    new JObject {
            //     {"From", new JObject {
            //      {"Email", "kernel-panic-11@yandex.com"},
            //      {"Name", "Gini"}
            //      }},
            //     {"To", new JArray {
            //      new JObject {
            //       {"Email", $"{mailRequest.ToEmail}"},
            //       {"Name", $"{mailRequest.ContactName}"}
            //       }
            //      }},
            //     {"Subject", "Verfication token"},
            //     {"TextPart", "Your otp is 1234"},
            //     {"HTMLPart", "<h3>Otp: 1234</h3>"}
            //     }
            //       });
            //MailjetResponse response = await client.PostAsync(request);
 */