using PatternFactoryMethod.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Factory_Method
{
    internal class PushCreator : NotificationCreator
    {
        public string AppToken { get; set; }
        public string AppId { get; set; }

        public PushCreator(string appToken, string appId)
        {
            AppToken = appToken;
            AppId = appId;
        }
        public override INotificationSender Create()
        {
            if (string.IsNullOrWhiteSpace(AppToken))
            {
                throw new ArgumentException("AppToken est invalide.");
            }
            else if (string.IsNullOrWhiteSpace(AppId))
            {
                throw new ArgumentException("AppId est invalide.");
            }
            else
            {
                return new PushSender();
            }
        }
    }
}
