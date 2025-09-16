using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Domain
{
    internal class SmsSender : INotificationSender
    {
        public bool Send(Message message)
        {
            
            if (message == null)
            {
                Console.WriteLine("Le message est égale a null.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(message.To))
            {
                Console.WriteLine("Il n'ya pas de destinataire.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(message.Body))
            {
                Console.WriteLine("Il n'ya pas de message.");
                return false;
            }
            else if (!Regex.IsMatch(message.To, "^\\+?\\d{8,15}$"))
            {
                Console.WriteLine("Le numéro de téléphone n'est pas valide.");
                return false;
            }
            else
            {
                Console.WriteLine($"[SMS] OK -> Numéro : {message.To}, Message : {message.Body}");
                return true;
            }
        }
    }
}
