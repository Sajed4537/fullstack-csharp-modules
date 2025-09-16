using OopFundamentals.App.Exceptions;
using OopFundamentals.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.App.Domain
{
    internal class Professeur : Utilisateur, IEmprunteur
    {
        public string Matiere {  get; set; }
        public Professeur(int id, string nom, string matiere) : base(id, nom)
        {
            Matiere = matiere;
        }

        public override void Presenter()
        {
            Console.WriteLine($"Le professeur s'apelle {Nom} et il enseigne la matière : {Matiere}");
        }

        public void EmprunterLivre(Livre livre)
        {
            if (livre.Disponible == true)
            {
                livre.Disponible = false;
            }
            else if (livre.Disponible == false)
            {
                throw new LivreIndisponibleException("Attention ! le livre n'est pas diponible.");
            }
        }

        public void RendreLivre(Livre livre)
        {
            if(livre.Disponible == true)
            {
                throw new LivreNonEmprunteException("Le livre n'a pas été emprunté");
            }
            else
            {
                livre.Disponible = true;
            }
        }
    }
}
