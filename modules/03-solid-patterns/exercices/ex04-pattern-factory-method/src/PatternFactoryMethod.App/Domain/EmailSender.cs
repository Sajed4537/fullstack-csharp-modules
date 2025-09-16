using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Domain
{
    internal class EmailSender : INotificationSender
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
            else if (!message.To.Contains("@"))
            {
                Console.WriteLine("L'adresse mail n'est pas valide, il manque un '@'.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(message.Title))
            {
                Console.WriteLine("Il n'y a pas de titre pour votre email.");
                return false;
            }
            else
            {
                Console.WriteLine($"[EMAIL] OK -> Destinataire : {message.To}, Titre : {message.Title}, Corps du mail : {message.Body}");
                return true;
            }
        }
    }
}
