using CatalogueMvc.App.Models;
using CatalogueMvc.App.ViewModels.Import;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace CatalogueMvc.App.Services.ImportServices
{
    public class XmlUserParser : IFileParser
    {
        public ImportPreviewVm Parse(ImportUploadVm importUpload)
        {
            var preview = new ImportPreviewVm();
            var erreurs = new List<string>();
            try
            {
                var listeUtilisateurs = new List<UtilisateurImportItemVm>();

                int lineNumber = 2;

                using var stream = importUpload.FormFile.OpenReadStream();

                var xmlDocument = XDocument.Load(stream);

                if (xmlDocument.Root.Name.LocalName != "Utilisateurs")
                {
                    erreurs.Add("Racine <Utilisateurs> attendue.");
                    preview.Erreurs = erreurs;
                    return preview;
                }

                var utilisateurs = from p in xmlDocument.Descendants().Where(e => e.Name.LocalName == "Utilisateur")
                               select new
                               {
                                   Nom = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Nom")?.Value,
                                   Prenom = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Prenom")?.Value,
                                   Email = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Email")?.Value,
                                   Type = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Type")?.Value
                               };


                foreach (var item in utilisateurs)
                {

                    var nom = item.Nom?.Trim();
                    var prenom = item.Prenom?.Trim();
                    var email = item.Email?.Trim();
                    var typeRaw = item.Type?.Trim();

                    var typeTest = Enum.TryParse<TypeUtilisateur>(typeRaw, ignoreCase: true, out TypeUtilisateur type);


                    if (string.IsNullOrWhiteSpace(nom))
                    {
                        erreurs.Add($"Ligne {lineNumber} : nom vide.");
                        lineNumber++;
                        continue;
                    }
                    else if (string.IsNullOrWhiteSpace(prenom))
                    {
                        erreurs.Add($"Ligne {lineNumber} : prénom vide.");
                        lineNumber++;
                        continue;
                    }
                    else if (string.IsNullOrWhiteSpace(email))
                    {
                        erreurs.Add($"Ligne {lineNumber} : email invalide : ('{email}').");
                        lineNumber++;
                        continue;
                    }
                    else if (!email.Contains("@") || !email.Contains("."))
                    {
                        erreurs.Add($"Ligne {lineNumber} : email invalide.");
                        lineNumber++;
                        continue;
                    }
                    else if (!typeTest)
                    {
                        erreurs.Add($"Ligne {lineNumber} : type invalide (‘{typeRaw}’).");
                        lineNumber++;
                        continue;
                    }
                    else
                    {
                        var utilisateur = new UtilisateurImportItemVm();
                        utilisateur.Nom = nom;
                        utilisateur.Prenom = prenom;
                        utilisateur.Email = email;
                        utilisateur.Type = type;
                        utilisateur.LigneSource = lineNumber;

                        listeUtilisateurs.Add(utilisateur);
                    }
                    lineNumber++;

                }
                preview.NbRejetees = erreurs.Count;
                preview.NbValides = listeUtilisateurs.Count;
                preview.TotalLignes = preview.NbValides + preview.NbRejetees;
                preview.Utilisateurs = listeUtilisateurs;
                preview.Erreurs = erreurs;
                preview.TypeDonnee = TypeDonnee.Utilisateurs;
                preview.Format = Format.XML;

                return preview;
            }
            catch (XmlException ex)
            {
                erreurs.Add(ex.Message);
                preview.Erreurs = erreurs;
                return preview;
            }
        }
    }
}
