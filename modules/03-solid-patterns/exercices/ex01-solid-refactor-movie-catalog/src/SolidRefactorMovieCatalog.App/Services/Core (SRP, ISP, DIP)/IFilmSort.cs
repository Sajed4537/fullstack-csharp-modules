using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal interface IFilmSort
    {
        IEnumerable<Film> ByTitleAscending(IEnumerable<Film> films);
        IEnumerable<Film> ByNoteAscending(IEnumerable<Film> films);
        IEnumerable<Film> ByNoteDescending(IEnumerable<Film> films);
    }
}
