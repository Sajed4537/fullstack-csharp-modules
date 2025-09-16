using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesAndAbstractClasses.App
{
    internal class Professeur : Personne,ITravailleur
    {
        private string Matiere;
        public Professeur(int id, string name, int age, string matiere) : base(id, name, age)
        {
            Matiere = matiere;
        }

        public override void Presenter()
        {
            Console.WriteLine($"Son nom est {Name} et son âge est de {Age}ans, il est professeur de {Matiere}");
        }

        public void Travailler()
        {
            Console.Write(" prépare et donne ses cours.");
        }
    }
}
