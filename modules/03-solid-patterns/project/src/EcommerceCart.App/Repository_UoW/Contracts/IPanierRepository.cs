using EcommerceCart.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Repository_UoW.Contracts
{
    internal interface IPanierRepository : IRepository<Panier>
    {
        Panier? GetPanierByUserId(int userId);

    }
}
