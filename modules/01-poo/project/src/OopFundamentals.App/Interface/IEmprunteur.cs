using OopFundamentals.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopFundamentals.App.Interface
{
    
    internal interface IEmprunteur
    {
        public void EmprunterLivre(Livre livre);

        void RendreLivre(Livre livre);
    }
}
