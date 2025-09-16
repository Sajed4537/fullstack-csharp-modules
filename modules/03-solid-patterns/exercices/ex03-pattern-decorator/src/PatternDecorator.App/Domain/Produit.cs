using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternDecorator.App.Domain
{
    internal class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public Produit(int  id, string nom)
        {
            Id = id;
            Nom = nom;
        }
    }
}
