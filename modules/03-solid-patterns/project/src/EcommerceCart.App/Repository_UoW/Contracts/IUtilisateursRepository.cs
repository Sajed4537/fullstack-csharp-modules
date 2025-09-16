using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.Contracts
{
    internal interface IUtilisateursRepository : IRepository<Utilisateurs>
    {
        Utilisateurs? FindByEmail(string email);
        Utilisateurs? FindByNomPrenom(string nom, string prenom);
        IEnumerable<Utilisateurs> ListByTypeUtilisateur(TypeUtilisateur type);
    }
}
