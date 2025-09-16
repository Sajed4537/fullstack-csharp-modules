using EcommerceCart.App.Adapter.Contracts;
using EcommerceCart.App.Adapter.Legacy;
using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Adapter.Adapters
{
    internal class CsvProduitsAdapter : IDataImporter<Produits>
    {
        private readonly LegacyCsvFile _legacyCsvFile;

        public CsvProduitsAdapter(LegacyCsvFile legacyCsvFile)
        {
            _legacyCsvFile = legacyCsvFile;
        }

        public IEnumerable<Produits> Load()
        {
            var legacy = _legacyCsvFile.ReadAll();

            if (string.IsNullOrWhiteSpace(legacy))
            {
                return Enumerable.Empty<Produits>();
            }
            else
            {
                legacy = legacy.Replace("\r\n", "\n");
                legacy = legacy.Replace("\r", "\n");

                var split = legacy.Split("\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                var produits = new List<Produits>();

                if (split.Length == 0)
                {
                    return Enumerable.Empty<Produits>();
                }

                if (split[0].ToLower().Trim() != "id,nom,prix,categories,stock")
                {
                    Console.WriteLine("[CSV] en-tête invalide");
                    return Enumerable.Empty<Produits>();
                }
                else
                {
                    for (int i = 1; i < split.Length; i++)
                    {
                        var split2 = split[i].Split(",", StringSplitOptions.TrimEntries);

                        var type = Enum.TryParse(split2[3], out Categories typeValue);

                        if (split2.Length != 5 || Convert.ToInt32(split2[0]) == 0 || string.IsNullOrWhiteSpace(split2[1]) 
                            || Convert.ToDecimal(split2[2]) == 0 || type == false || Convert.ToInt32(split2[4]) == 0)
                        {
                            Console.WriteLine($"[CSV] ligne {split[i]} ignorée: 5 colonnes attendues\" / Id invalide / Nom vide / Prix invalide/ Categories invalide/ Stock invalide");
                            continue;
                        }

                        
                        var prix = Convert.ToDecimal(split2[2]);
                        var stock = Convert.ToInt32(split2[4]);

                        var contact = new Produits(split2[1], prix, typeValue, stock);
                        produits.Add(contact);
                    }

                    return produits;
                }
            }
        }
    }
}
