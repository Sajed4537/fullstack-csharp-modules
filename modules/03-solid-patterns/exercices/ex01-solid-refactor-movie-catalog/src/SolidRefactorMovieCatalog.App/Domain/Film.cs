using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App.Domain
{
    internal class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Genre { get; set; }
        public int NoteSur10 { get; set; }
        public int Annee { get; set; }
        public string Realisateur { get; set; }

        public Film(int id, string titre, string genre, int noteSur10, int annee, string realisateur)
        {
            Id = id;
            Titre = titre;
            Genre = genre;
            NoteSur10 = noteSur10;
            Annee = annee;
            Realisateur = realisateur;
        }

        public override bool Equals(object? obj)
        {

            if (obj is Film other)
            {
                return Id == other.Id;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void Afficher()
        {
            Console.WriteLine($"Id : {Id} - Titre : {Titre} - Genre : {Genre} - Note : {NoteSur10} - Année : {Annee} - Réalisateur : {Realisateur}");
        }
    }
}
