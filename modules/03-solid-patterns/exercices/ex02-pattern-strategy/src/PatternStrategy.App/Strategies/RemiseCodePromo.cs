using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.App.Strategies
{
    internal class RemiseCodePromo : IRemiseStrategy
    {
        private Dictionary<string, decimal> RemiseFixe {  get; set; }
        private Dictionary<string, decimal> RemisePourcentage {  get; set; }

        public string Code {  get; set; }
        public RemiseCodePromo(string code) 
        {
            Code = code;
            RemiseFixe = new Dictionary<string, decimal>()
            {
                {"PROMO10",10m }
            };

            RemisePourcentage = new Dictionary<string, decimal>()
            {
                {"NOEL20",20m }
            };
        }

        public decimal CalculRemise(decimal prixTotal)
        {

            if (RemiseFixe.TryGetValue(Code, out var montantFixe))
            {
                return montantFixe;
            }
            else if(RemisePourcentage.TryGetValue(Code, out var taux))
            {
                return prixTotal * (taux / 100);
            }
            else
            {
                Console.WriteLine("Le code que vous avez saisi n'est pas valide.");
                return 0;
            }
        }
    }
}
