using OopFundamentals.App.Exceptions;
using OopFundamentals.App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.App.Domain
{
    internal class Etudiant : Utilisateur, IEmprunteur
    {
        public string Niveau { get; set; }
        public Etudiant(int id, string nom, string niveau) : base(id, nom)
        {
            Niveau = niveau;
        }

        public override void Presenter()
        {
            Console.WriteLine($"L'étudiant s'apelle {Nom} et il en {Niveau}");
        }

        public void EmprunterLivre(Livre livre)
        {
            if(livre.Disponible == true)
            {
                livre.Disponible = false;
            }
            else if(livre.Disponible == false)
            {
                throw new LivreIndisponibleException("Attention ! le livre n'est pas diponible.");
            }
        }

        public void RendreLivre(Livre livre)
        {
            livre.Disponible = true;
        }
    }
}
