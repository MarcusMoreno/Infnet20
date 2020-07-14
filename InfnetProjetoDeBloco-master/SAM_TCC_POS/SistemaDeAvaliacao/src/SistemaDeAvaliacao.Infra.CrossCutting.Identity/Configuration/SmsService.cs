using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SistemaDeAvaliacao.Infra.CrossCutting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage identityMessage)
        {
            // Utilizando TWILIO como SMS Provider.
            // https://www.twilio.com/docs/quickstart/csharp/sms/sending-via-rest

            const string accountSid = "SEU ID";
            const string authToken = "SEU TOKEN";

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+15017250604");
            var message = MessageResource.Create(
                to: new PhoneNumber(identityMessage.Destination),
                from: new PhoneNumber("+15017250604"),
                body: identityMessage.Body
                );
            Console.WriteLine(message.DateCreated);

            //var client = new TwilioRestClient(accountSid, authToken);
            //client.SendMessage("Seu Telefone", message.Destination, message.Body);

            return Task.FromResult(0);
        }
    }
}