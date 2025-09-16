using System;

namespace EncapsulationAndValidation.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Personne> personnes = new List<Personne>
            {
                new Personne(1, "Sajed", 23),
                new Personne(2, "Ali", 30),
                new Personne(3, "Marie", 25)

            };

            Personne personne1 = new Personne(4, "", -12);


            foreach (Personne personne in personnes)
            {
                personne.Afficher();
            }
        }
    }
}