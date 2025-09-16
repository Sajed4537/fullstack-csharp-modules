using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Domain
{
    internal class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Project(string name)
        {
            Name = name;
        }
    }
}
