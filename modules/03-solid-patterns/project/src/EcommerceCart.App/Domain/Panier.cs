using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Domain
{
    internal class Panier
    {
        public int Id { get; set; }
        public int IdUtilisateur { get; set; }
        public List<Produits> Produits { get; set; }
        public Panier() 
        {
            Produits = new List<Produits>();
        }
    }
}
