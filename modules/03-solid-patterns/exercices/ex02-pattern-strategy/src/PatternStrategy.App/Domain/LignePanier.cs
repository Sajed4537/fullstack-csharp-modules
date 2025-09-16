using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternStrategy.App.Domain
{
    internal class LignePanier
    {
        public Produit Produit { get; set; }

        private int _quantite;
        public int Quantite 
        {
            get => _quantite;
            set
            {
                if(value <= 0)
                {
                    throw new Exception("La valeur ne peut pas étre égale ou inférieur à 0.");
                }
                else
                {
                    _quantite = value;
                }
            }
        }

        private decimal _prixUnitaire;
        public decimal PrixUnitaire 
        {
            get => _prixUnitaire;
            set
            {
                if(value <= 0)
                {
                    throw new Exception("La valeur ne peut pas étre égale ou inférieur à 0.");
                }
                else
                {
                    _prixUnitaire = value;
                }
            }
        }

        public LignePanier(Produit produit, int quantite, decimal prixUnitaire)
        {
            Produit = produit;
            Quantite = quantite;
            PrixUnitaire = prixUnitaire;
        }
    }
}
