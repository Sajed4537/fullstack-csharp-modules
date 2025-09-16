using PatternAdapter.App.Adapters.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternAdapter.App.Services
{
    internal class ContactService
    {

        public ContactService() { }

        public void LoadAllContacts(IContactFeed contactFeed)
        {
            var contacts = contactFeed.Load();

            foreach (var contact in contacts)
            {
                Console.WriteLine($"First name : {contact.FirstName} - Last name : {contact.LastName} - Email : {contact.Email}");
            }
        }
    }
}
