using CatalogueMvc.App.Models;
using CatalogueMvc.App.ViewModels.Import;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

namespace CatalogueMvc.App.Services.ImportServices
{
    public class XmlProductParser : IFileParser
    {
        public ImportPreviewVm Parse(ImportUploadVm importUpload)
        {
            var preview = new ImportPreviewVm();
            var erreurs = new List<string>();
            try
            {
                var listeProduit = new List<ProduitImportItemVm>();

                int lineNumber = 2;

                using var stream = importUpload.FormFile.OpenReadStream();

                var xmlDocument = XDocument.Load(stream);

                if (xmlDocument.Root.Name.LocalName != "Produits")
                {
                    erreurs.Add("Racine <Produits> attendue.");
                    preview.Erreurs = erreurs;
                    return preview;
                }

                var produits = from p in xmlDocument.Descendants().Where(e => e.Name.LocalName == "Produit")
                               select new
                               {
                                   Nom = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Nom")?.Value,
                                   Prix = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Prix")?.Value,
                                   Categorie = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Categorie")?.Value,
                                   Stock = p.Elements().FirstOrDefault(e => e.Name.LocalName == "Stock")?.Value
                               };

               
                foreach (var item in produits)
                {

                    var nom = item.Nom?.Trim();
                    var catRaw = item.Categorie?.Trim();
                    var prixRaw = item.Prix?.Trim();
                    var stockRaw = item.Stock?.Trim();

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
                        var produit = new ProduitImportItemVm();

                        produit.Nom = nom;
                        produit.Categorie = categorie;
                        produit.Prix = prix;
                        produit.Stock = stock;
                        produit.LigneSource = lineNumber;

                        listeProduit.Add(produit);
                    }
                    lineNumber++;

                }
                preview.NbRejetees = erreurs.Count;
                preview.NbValides = listeProduit.Count;
                preview.TotalLignes = preview.NbValides + preview.NbRejetees;
                preview.Produits = listeProduit;
                preview.Erreurs = erreurs;
                preview.TypeDonnee = TypeDonnee.Produits;
                preview.Format = Format.XML;

                return preview;
            }
            catch (XmlException ex)
            {
                erreurs.Add (ex.Message);
                preview.Erreurs = erreurs;
                return preview;
            }



        }
    }
}
