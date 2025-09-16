using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCart.App.Adapter.Contracts
{
    internal interface IDataImporter<T>
    {
        IEnumerable<T> Load();
    }
}
