using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetAndEquality.App
{
    internal class Produit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Categorie { get; set; }
        public decimal Prix { get; set; }

        public Produit(int id, string name, string categorie, decimal prix)
        {
            Id = id;
            Name = name;
            Categorie = categorie;
            Prix = prix;
        }

        public void Afficher()
        {
            Console.WriteLine($"Id : {Id} - Nom : {Name} - Catégorie : {Categorie} - Prix : {Prix} euro");
        }

        public override bool Equals(object obj)
        {
            if (obj is Produit other)
            {
                return this.Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
