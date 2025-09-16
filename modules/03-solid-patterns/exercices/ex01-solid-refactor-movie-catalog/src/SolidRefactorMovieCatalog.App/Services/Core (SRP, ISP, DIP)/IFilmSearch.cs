using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal interface IFilmSearch
    {
        Film? GetById(int id);
        IEnumerable<Film> FindByTitle(string title);
        IEnumerable<Film> FindByGenre(string genre);
    }
}
