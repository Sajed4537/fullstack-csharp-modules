using System;

namespace InheritanceAndPolymorphism.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Personne> personnes = new List<Personne>
           {
                new Etudiant(1, "Sajed", 23, "Master 2", 19),
                new Etudiant(2, "Souheil", 17, "Terminal", 18),
                new Professeur(3, "Jean", 35, "Mathématique")
           };

            

            foreach(Personne personne in personnes)
            {
                personne.Presenter();
            }
        }
    }
}