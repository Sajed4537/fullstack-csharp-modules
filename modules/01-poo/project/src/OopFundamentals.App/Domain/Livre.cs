using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.App.Domain
{
    internal class Livre
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public bool Disponible {  get; set; }
        

        public Livre(int id, string titre, string auteur, bool disponible)
        {
            Id = id;
            Titre = titre;
            Auteur = auteur;
            Disponible = disponible;

        }

        public void Afficher()
        {
            if (Disponible)
            {
                Console.WriteLine($"Livre {Id} - {Titre} - par Auteur {Auteur} - Disponible");
            }
            else if(!Disponible)
            {
                Console.WriteLine($"Livre {Id} - {Titre} - par Auteur {Auteur} - Emprunté");
            }
        }
    }
}
