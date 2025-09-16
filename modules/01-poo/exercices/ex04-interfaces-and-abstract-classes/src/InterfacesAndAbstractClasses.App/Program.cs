using System;

namespace InterfacesAndAbstractClasses.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var etudiants = new List<Etudiant>
                {
                new Etudiant(1, "Sajed", 23, "Master 2", 19),
                new Etudiant(2, "Souheil", 17, "Terminal", 18)
                };

            var professeurs = new List<Professeur>
            {
                new Professeur(3, "Jean", 35, "Mathématique"),
                new Professeur(4, "Michel", 48, "Français")
            };

            foreach (var e in etudiants)
            {
                e.Presenter();
                Console.Write(e.Name);
                e.Travailler();
                Console.WriteLine();
                Console.WriteLine();
            }

            foreach (var p in professeurs)
            {
                p.Presenter();
                Console.Write(p.Name);
                p.Travailler();
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}