using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Decorator
{
    internal class Surcharge
    {
        public string Nom {  get; set; }
        public decimal Montant { get; set; }

        public Surcharge(string nom, decimal montant)
        {
            Nom = nom;
            Montant = montant;
        }
    }
}
