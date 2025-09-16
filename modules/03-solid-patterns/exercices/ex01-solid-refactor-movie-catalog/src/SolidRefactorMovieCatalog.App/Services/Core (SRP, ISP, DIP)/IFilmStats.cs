using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal interface IFilmStats
    {
        IEnumerable<GenreStats> GroupByGenre(IEnumerable<Film> films);
    }
}
