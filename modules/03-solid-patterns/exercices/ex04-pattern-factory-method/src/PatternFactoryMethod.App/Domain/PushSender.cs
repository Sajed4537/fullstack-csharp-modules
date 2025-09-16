using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Domain
{
    internal class PushSender : INotificationSender
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

            bool idValide = System.Text.RegularExpressions.Regex.IsMatch(message.To, @"^[A-Za-z0-9_-]+$");
            if (!idValide) 
            { 
                Console.WriteLine("L'identifiant est invalide."); 
                return false; 
            }
            else
            {
                Console.WriteLine($"[PUSH] OK -> Id : {message.To}");
                return true;
            }
        }
    }
}
