using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.App.Domain
{
    internal class Utilisateur
    {
        public int Id {  get; set; }
        public string Nom { get; set;}

        public Utilisateur(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }


        public virtual void Presenter()
        {
            Console.WriteLine($"La personne est {Nom}");
        }


    }
}
