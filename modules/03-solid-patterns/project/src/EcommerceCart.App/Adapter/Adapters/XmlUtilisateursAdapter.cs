using EcommerceCart.App.Adapter.Contracts;
using EcommerceCart.App.Adapter.Legacy;
using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EcommerceCart.App.Adapter.Adapters
{
    internal class XmlUtilisateursAdapter : IDataImporter<Utilisateurs>
    {
        private readonly LegacyXmlFile _legacyXmlFile;
        public XmlUtilisateursAdapter(LegacyXmlFile legacyXmlFile) 
        {
            _legacyXmlFile = legacyXmlFile;
        }
        public IEnumerable<Utilisateurs> Load()
        {
            var ustilisateurs = new List<Utilisateurs>();

            var legacy = _legacyXmlFile.ReadAll();

            try
            {
                var xml = XDocument.Parse(legacy);
                var UtilisateursElements = xml.Descendants("utilisateurs");

                foreach (var element in UtilisateursElements)
                {
                    var nom = element.Element("Nom")?.Value?.Trim();
                    var prenom = element.Element("Prenom")?.Value?.Trim();
                    var email = element.Element("Email")?.Value?.Trim();
                    var testType = element.Element("Type")?.Value?.Trim();
                    var type = Enum.TryParse(testType, out TypeUtilisateur typeValue);

                    if (string.IsNullOrWhiteSpace(nom) ||
                        string.IsNullOrWhiteSpace(prenom) ||
                        string.IsNullOrWhiteSpace(email) ||
                        string.IsNullOrWhiteSpace(testType))
                        continue;

                    ustilisateurs.Add(new Utilisateurs(nom, prenom, email, typeValue));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du parsing XML : {ex.Message}");
            }

            return ustilisateurs;
        }
    }
}
