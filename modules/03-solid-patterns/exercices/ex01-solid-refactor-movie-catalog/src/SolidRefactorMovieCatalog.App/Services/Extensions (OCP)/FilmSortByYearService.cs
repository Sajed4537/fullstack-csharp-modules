using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal class FilmSortByYearService : IFilmSortByYear
    {
        public IEnumerable<Film> ByYearDescending(IEnumerable<Film> films)
        {
            return films.OrderBy(i => i.Annee).ToList();
        }
    }
}
