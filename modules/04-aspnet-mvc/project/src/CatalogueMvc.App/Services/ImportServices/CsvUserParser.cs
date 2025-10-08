using CatalogueMvc.App.Models;
using CatalogueMvc.App.ViewModels.Import;

namespace CatalogueMvc.App.Services.ImportServices
{
    public class CsvUserParser : IFileParser
    {
        public ImportPreviewVm Parse(ImportUploadVm importUpload)
        {
            var vm = importUpload.FormFile.OpenReadStream();

            var preview = new ImportPreviewVm();

            var listeUtilisateurs = new List<UtilisateurImportItemVm>();

            var erreurs = new List<string>();

            int lineNumber = 2;

            using (var reader = new StreamReader(vm, new System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier: false), detectEncodingFromByteOrderMarks: true))
            {
                var firstLine = reader.ReadLine();

                if (firstLine == null)
                {
                    erreurs.Add("En-tête manquant.");
                    return preview;
                }

                var colonnes = firstLine.Split(";");

                if (colonnes.Length != 4)
                {
                    erreurs.Add("En-tête invalide (attendu : Nom;Prenom;Email;Type)");
                    return preview;
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line)) 
                    { 
                        lineNumber++; 
                        continue; 
                    }

                    var values = line.Split(";");

                    if (values.Length != 4)
                    {
                        erreurs.Add($"Ligne {lineNumber} : nombre de colonnes invalide (attendu 4).");
                        lineNumber++;
                        continue;
                    }

                    var nom = values[0]?.Trim();
                    var prenom = values[1]?.Trim();
                    var email = values[2]?.Trim();
                    var typeRaw = values[3]?.Trim();

                    var utilisateurs = new UtilisateurImportItemVm();

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
                        utilisateurs.Nom = nom;
                        utilisateurs.Prenom = prenom;
                        utilisateurs.Email = email;
                        utilisateurs.Type = type;
                        utilisateurs.LigneSource = lineNumber;

                        listeUtilisateurs.Add(utilisateurs);
                    }
                    lineNumber++;

                }
            }

            preview.NbRejetees = erreurs.Count;
            preview.NbValides = listeUtilisateurs.Count;
            preview.TotalLignes = preview.NbValides + preview.NbRejetees;
            preview.Utilisateurs = listeUtilisateurs;
            preview.Erreurs = erreurs;
            preview.TypeDonnee = TypeDonnee.Utilisateurs;
            preview.Format = Format.CSV;

            return preview;
        }
    }
}
