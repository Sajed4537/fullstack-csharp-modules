using PatternFactoryMethod.App.Domain;
using PatternFactoryMethod.App.Factory_Method;
using System;

namespace PatternFactoryMethod.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool result = false;
                var mail = new Message("email@yahoo.com", "Salut", "Bonjour !");

                var telephone = new Message("098475634", "toto", "titi");

                var _push = new Message("U_42", "Salut", "Bonjour !");

                var channel = "Sms";

                INotificationSender sender = null;

                if (channel == "Email")
                {
                    var email = new EmailCreator("smtp.local", 456, "noreply@ex.com");
                    sender = email.Create();
                    result = sender.Send(mail);
                }
                else if (channel == "Sms")
                {
                    var sms = new SmsCreator("demo-key", "MyApp");
                    sender = sms.Create();
                    result = sender.Send(telephone);
                }
                else if (channel == "Push")
                {
                    var push = new PushCreator("app-token-123", "notify-app");
                    sender = push.Create();
                    result = sender.Send(_push);
                }
                else
                {
                    throw new Exception("Le canal est invalide veuillez choisir un des trois : Email - Sms - Push");
                }


                if (result)
                {
                    Console.WriteLine("Succès");
                }
                else if (!result)
                {
                    Console.WriteLine("Échec");
                }

                
            }
            catch(Exception ex) 
            {
                Console.Write(ex.Message);
            }
        }
    }
}