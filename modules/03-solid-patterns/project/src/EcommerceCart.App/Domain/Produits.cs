using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Domain
{
    enum Categories
    {
        Alimentation,
        HygieneEtBeaute,
        EntretienMaison,
        EquipementMaison,
        TextileEtHabillement,
        EnfantsEtBebes,
        MultimediaEtLoisirs,
        Animalerie
    } 
    internal class Produits
    {
        public int Id {  get; set; }
        public string Nom {  get; set; }
        public decimal Prix { get; set; }
        public Categories Categories { get; set; }
        public int Stock {  get; set; }
        public Produits(string nom, decimal prix, Categories categories, int stock) 
        {
            Nom = nom;
            Prix = prix;
            Categories = categories;
            Stock = stock;
        }
    }
}
