using OopFundamentals.App.Domain;
using System;

namespace Projet_Module_1_Gestion_dune_Bibliotheque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Livre> livres = new List<Livre>
            {
                new Livre(1, "livre 1", "auteur 1", true),
                new Livre(2, "livre 2", "auteur 2", true),
                new Livre(3, "livre 3", "auteur 3", true),
                new Livre(4, "livre 4", "auteur 4", true),
                new Livre(5, "livre 5", "auteur 5", true),
            };

            List<Professeur> professeurs = new List<Professeur>
            {
                new Professeur(1, "utilisateur 1", "Matiere 1"),
                new Professeur(2, "utilisateur 2", "Matiere 2"),
                new Professeur(3, "utilisateur 3", "Matiere 3")
            };

            List<Etudiant> etudiants = new List<Etudiant>
            {
                new Etudiant(4, "utilisateur 4", "Niveau x"),
                new Etudiant(5, "utilisateur 5", "Niveau x")
            };

            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            foreach (Professeur professeur in professeurs)
            {
                utilisateurs.Add(professeur);
            }

            foreach (Etudiant etudiant in etudiants)
            {
                utilisateurs.Add(etudiant);
            }


            Bibliotheque bibliotheque = new Bibliotheque();

            foreach (Livre livre in livres)
            {
                bibliotheque.Livres.Add(livre);
            }

            foreach (Utilisateur utilisateur in utilisateurs)
            {
                bibliotheque.Utilisateurs.Add(utilisateur);
            }

            bibliotheque.AfficherLivres();

            Professeur professeur1 = professeurs[0];

            Etudiant etudiant1 = etudiants[0];

            professeur1.EmprunterLivre(livres[0]);

            etudiant1.EmprunterLivre(livres[1]);

            Console.WriteLine();
            Console.WriteLine();

            bibliotheque.AfficherLivres();

            // Test exception
            //professeur1.EmprunterLivre(livres[1]);

            etudiant1.RendreLivre(livres[1]);

            Console.WriteLine();
            Console.WriteLine();

            bibliotheque.AfficherLivres();

            bibliotheque.SupprimerLivre(bibliotheque.Livres[0].Id);

            Console.WriteLine();
            Console.WriteLine();

            bibliotheque.AfficherLivres();

            Console.WriteLine();
            Console.WriteLine();

            // Test exception
            //bibliotheque.SupprimerLivre(1);

            foreach (Utilisateur utilisateur in utilisateurs)
            {
                utilisateur.Presenter();
            }


        }
    }
}