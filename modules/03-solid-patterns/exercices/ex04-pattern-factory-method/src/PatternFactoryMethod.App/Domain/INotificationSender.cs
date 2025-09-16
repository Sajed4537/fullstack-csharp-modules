using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Domain
{
    internal interface INotificationSender
    {
        public bool Send(Message message);
    }
}
