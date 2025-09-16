using OopFundamentals.App.Exceptions;
using Projet_Module_1_Gestion_dune_Bibliotheque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.App.Domain
{
    internal class Bibliotheque
    {
        public List<Livre> Livres { get; set; } = new List<Livre>();
        public List<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();

        public void AjouterLivre(Livre livre)
        {
            Livres.Add(livre);
        }

        public void SupprimerLivre(int id)
        {
            bool livreTrouve = false;

            for(int i = 0; i < Livres.Count; i++)
            {
                if(Livres[i].Id == id)
                {
                    Livres.Remove(Livres[i]);
                    livreTrouve = true;
                    break;
                }
            }
            if (livreTrouve == false)
            {
                throw new LivreInexistantException("Attention ! le livre n'existe pas.");
            }
        }

        public void AfficherLivres()
        {
            foreach(Livre livre in Livres)
            {
                livre.Afficher();
            }
        }

        public void AjouterUtilisateur( Utilisateur utilisateur)
        {
            Utilisateurs.Add(utilisateur);
        }

        public void AfficherUtilisateur()
        {
            foreach(Utilisateur utilisateur in Utilisateurs)
            {
                utilisateur.Presenter();
            }
        }
    }
}
