using PatternFactoryMethod.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Factory_Method
{
    internal abstract class NotificationCreator
    {
        public abstract INotificationSender Create();
    }
}
