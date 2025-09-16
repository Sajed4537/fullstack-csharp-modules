using PatternFactoryMethod.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Factory_Method
{
    internal class SmsCreator : NotificationCreator
    {
        public string ApiKey { get; set; }
        public string Sender { get; set; }

        public SmsCreator(string apiKey, string sender)
        {
            ApiKey = apiKey;
            Sender = sender;
        }

        public override INotificationSender Create()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                throw new ArgumentException("ApiKey est invalide.");
            }
            else if (string.IsNullOrWhiteSpace(Sender))
            {
                throw new ArgumentException("Sender est invalide.");
            }
            else
            {
                return new SmsSender();
            }
        }
    }
}
