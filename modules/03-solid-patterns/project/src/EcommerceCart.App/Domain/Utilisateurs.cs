using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Domain
{
    enum TypeUtilisateur {Administrateur, Client}
    internal class Utilisateurs
    {
        public int Id { get; set; }
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public TypeUtilisateur Type { get; set; }

        public Utilisateurs(string nom, string prenom, string email, TypeUtilisateur type)
        {
            Nom = nom;
            Email = email;
            Type = type;
            Prenom = prenom;
        }
    }
}
