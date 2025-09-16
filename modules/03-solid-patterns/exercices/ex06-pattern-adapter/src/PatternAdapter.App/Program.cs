using PatternAdapter.App.Adapters.Concrete;
using PatternAdapter.App.Adapters.Legacy;
using PatternAdapter.App.Services;
using System;

namespace PatternAdapter.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactService contactService = new ContactService();

            LegacyCsvFile legacyCsvFile = new LegacyCsvFile("Data/contacts.csv");

            CsvContactAdapter csvContactAdapter = new CsvContactAdapter(legacyCsvFile);

            Console.WriteLine("Fichier CSV :");

            Console.WriteLine();

            contactService.LoadAllContacts(csvContactAdapter);

            Console.WriteLine();
            Console.WriteLine();

            LegacyXmlFile legacyXmlFile = new LegacyXmlFile("Data/contacts.xml");

            XmlContactAdapter xmlContactAdapter = new XmlContactAdapter(legacyXmlFile);

            Console.WriteLine("Fichier XAML :");

            Console.WriteLine();

            contactService.LoadAllContacts(xmlContactAdapter);
        }
    }
}