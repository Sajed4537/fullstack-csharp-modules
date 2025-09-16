using PatternAdapter.App.Adapters.Contracts;
using PatternAdapter.App.Adapters.Legacy;
using PatternAdapter.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PatternAdapter.App.Adapters.Concrete
{
    internal class XmlContactAdapter : IContactFeed
    {
        private readonly LegacyXmlFile LegacyXmlFile;

        public XmlContactAdapter(LegacyXmlFile legacyXmlFile)
        {
            LegacyXmlFile = legacyXmlFile;
        }

        public IEnumerable<Contact> Load()
        {
            var contacts = new List<Contact>();

            var legacy = LegacyXmlFile.ReadAll();

            try
            {
                var xml = XDocument.Parse(legacy);
                var contactElements = xml.Descendants("contact");

                foreach (var element in contactElements)
                {
                    var firstname = element.Element("firstName")?.Value?.Trim();
                    var lastname = element.Element("lastName")?.Value?.Trim();
                    var email = element.Element("email")?.Value?.Trim();

                    if (string.IsNullOrWhiteSpace(firstname) ||
                        string.IsNullOrWhiteSpace(lastname) ||
                        string.IsNullOrWhiteSpace(email))
                        continue;

                    contacts.Add(new Contact(firstname, lastname, email));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du parsing XML : {ex.Message}");
            }

            return contacts;
        }

    }
}
