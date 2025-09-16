using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism.App
{
    internal class Etudiant : Personne
    {
        private string Niveau;
        private decimal Moyenne;
        public Etudiant(int id, string name, int age, string niveau, decimal moyenne) : base(id, name, age)
        {
            Niveau = niveau;
            Moyenne = moyenne;
        }

        public override void Presenter()
        {
            Console.WriteLine($"Son nom est {Name} et son âge est de {Age}ans, il est étudiant en {Niveau} et il a {Moyenne} de moyenne générale");
        }
    }
}
