using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUnitOfWork.App.Domain
{
    internal class User
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }

        public User(string displayName, string email)
        {
            DisplayName = displayName;
            Email = email;
        }
    }
}
