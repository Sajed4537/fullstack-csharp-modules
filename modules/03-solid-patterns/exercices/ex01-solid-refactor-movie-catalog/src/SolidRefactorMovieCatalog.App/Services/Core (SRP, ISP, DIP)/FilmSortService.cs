using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal class FilmSortService : IFilmSort
    {
        public IEnumerable<Film> ByNoteAscending(IEnumerable<Film> films)
        {
            return films.OrderBy(i => i.NoteSur10).ToList();
        }

        public IEnumerable<Film> ByNoteDescending(IEnumerable<Film> films)
        {
            return films.OrderByDescending(i => i.NoteSur10).ToList();
        }

        public IEnumerable<Film> ByTitleAscending(IEnumerable<Film> films)
        {
            return films.OrderBy(i => i.Titre).ToList();
        }
    }
}
