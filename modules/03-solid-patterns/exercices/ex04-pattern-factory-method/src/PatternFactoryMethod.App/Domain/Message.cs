using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternFactoryMethod.App.Domain
{
    internal class Message
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public Message(string to, string title, string body) 
        {
            To = to;
            Title = title;
            Body = body;
        }
    }
}
