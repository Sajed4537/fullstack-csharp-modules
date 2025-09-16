using PatternFactoryMethod.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Factory_Method
{
    internal class EmailCreator : NotificationCreator
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string From { get; set; }

        public EmailCreator(string host, int port, string from)
        {
            Host = host;
            Port = port;
            From = from;

        }
        public override INotificationSender Create()
        {
            if (string.IsNullOrWhiteSpace(Host))
            {
                throw new ArgumentException("Host manquant.");
            }
            else if (Port <= 0 || Port > 65535)
            {
                throw new ArgumentException("Port invalide.");
            }
            else if(string.IsNullOrWhiteSpace(From) || !From.Contains("@"))
            {
                throw new ArgumentException("From invalide.");
            }
            else
            {
                return new EmailSender();
            }
        }
    }
}
