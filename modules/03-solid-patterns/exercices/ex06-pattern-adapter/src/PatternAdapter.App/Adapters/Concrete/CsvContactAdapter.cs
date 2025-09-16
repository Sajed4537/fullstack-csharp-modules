using PatternAdapter.App.Adapters.Contracts;
using PatternAdapter.App.Adapters.Legacy;
using PatternAdapter.App.Domain;
namespace PatternAdapter.App.Adapters.Concrete
{
    internal class CsvContactAdapter : IContactFeed
    {
        private readonly  LegacyCsvFile LegacyCsvFile;

        public CsvContactAdapter(LegacyCsvFile legacyCsvFile)
        {
            LegacyCsvFile = legacyCsvFile;
        }

        public IEnumerable<Contact> Load()
        {
            var legacy = LegacyCsvFile.ReadAll();

            if (string.IsNullOrWhiteSpace(legacy))
            {
                return Enumerable.Empty<Contact>();
            }
            else
            {
                legacy = legacy.Replace("\r\n", "\n");
                legacy = legacy.Replace("\r", "\n");

                var split = legacy.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var contacts = new List<Contact>();

                if(split.Length == 0)
                {
                    return Enumerable.Empty<Contact>();
                }

                if (split[0].ToLower().Trim() != "firstname,lastname,email")
                {
                    Console.WriteLine("[CSV] en-tête invalide");
                    return Enumerable.Empty<Contact>();
                }
                else
                {
                    for (int i = 1; i < split.Length; i++)
                    {
                        var split2 = split[i].Split(",", StringSplitOptions.TrimEntries);

                        if (split2.Length != 3 || string.IsNullOrWhiteSpace(split2[0]) || string.IsNullOrWhiteSpace(split2[1]) || !split2[2].Contains("@") || split2[2].Contains(" "))
                        {
                            Console.WriteLine($"[CSV] ligne {split[i]} ignorée: 3 colonnes attendues\" / firstName vide / email invalide");
                            continue;
                        }

                        var contact = new Contact(split2[0], split2[1], split2[2]);
                        contacts.Add(contact);
                    }

                    return contacts;
                }
            }
        }
    }
}
