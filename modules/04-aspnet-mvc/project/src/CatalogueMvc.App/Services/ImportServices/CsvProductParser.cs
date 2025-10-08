using CatalogueMvc.App.Models;
using CatalogueMvc.App.ViewModels.Import;
using System.Globalization;

namespace CatalogueMvc.App.Services.ImportServices
{
    public class CsvProductParser : IFileParser
    {
        public ImportPreviewVm Parse(ImportUploadVm importUpload)
        {

            var vm = importUpload.FormFile.OpenReadStream();

            var preview = new ImportPreviewVm();

            var listeProduit = new List<ProduitImportItemVm>();
            
            var erreurs = new List<string>();

            int lineNumber = 2;

            using (var reader = new StreamReader(vm,new System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier: false), detectEncodingFromByteOrderMarks: true))
            {
                var firstLine = reader.ReadLine();

                if(firstLine == null)
                {
                    erreurs.Add("En-tête manquant.");
                    return preview;
                }

                var colonnes = firstLine.Split(";");

                if(colonnes.Length != 4)
                {
                    erreurs.Add("En-tête invalide (attendu : Nom;Categorie;Prix;Stock)");
                    return preview;
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(";");

                    if(values.Length != 4)
                    {
                        erreurs.Add($"Ligne {lineNumber} : nombre de colonnes invalide (attendu 4).");
                        lineNumber++;
                        continue;
                    }

                    var nom = values[0]?.Trim();
                    var catRaw = values[1]?.Trim();
                    var prixRaw = values[2]?.Trim();
                    var stockRaw = values[3]?.Trim();

                    var produits = new ProduitImportItemVm();

                    var prixTest = decimal.TryParse(prixRaw, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal prix);

                    var stockTest = int.TryParse(stockRaw, NumberStyles.Integer, CultureInfo.InvariantCulture, out var stock);

                    var categorieTest = Enum.TryParse<Categorie>(catRaw, ignoreCase: true, out Categorie categorie);

                    if (string.IsNullOrWhiteSpace(nom))
                    {
                        erreurs.Add($"Ligne {lineNumber} : nom vide.");
                        lineNumber++;
                        continue;
                    }
                    else if (!stockTest)
                    {
                        erreurs.Add($"Ligne {lineNumber} : stock invalide (‘{stockRaw}’).");
                        lineNumber++;
                        continue;
                    }
                    else if (!categorieTest)
                    {
                        erreurs.Add($"Ligne {lineNumber} : catégorie invalide (‘{catRaw}’).");
                        lineNumber++;
                        continue;
                    }
                    else if (!prixTest)
                    {
                        erreurs.Add($"Ligne {lineNumber} : prix invalide (‘{prixRaw}’).");
                        lineNumber++;
                        continue;
                    }
                    else if (prix < 0)
                    { 
                        erreurs.Add($"Ligne {lineNumber} : prix négatif (‘{prixRaw}’).");
                        lineNumber++;
                        continue;
                    }
                    else if (stock < 0) 
                    { 
                        erreurs.Add($"Ligne {lineNumber} : stock négatif (‘{stockRaw}’).");
                        lineNumber++;
                        continue;
                    }
                    else
                    {
                        produits.Nom = nom;
                        produits.Categorie = categorie;
                        produits.Prix = prix;
                        produits.Stock = stock;
                        produits.LigneSource = lineNumber;

                        listeProduit.Add(produits);
                    }
                    lineNumber++;

                }
            }

            preview.NbRejetees = erreurs.Count;
            preview.NbValides = listeProduit.Count;
            preview.TotalLignes = preview.NbValides + preview.NbRejetees;
            preview.Produits = listeProduit;
            preview.Erreurs = erreurs;
            preview.TypeDonnee = TypeDonnee.Produits;
            preview.Format = Format.CSV;

            return preview;

        }
    }
}
