using PatternAdapter.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternAdapter.App.Adapters.Contracts
{
    internal interface IContactFeed
    {
        IEnumerable<Contact> Load();
    }
}
