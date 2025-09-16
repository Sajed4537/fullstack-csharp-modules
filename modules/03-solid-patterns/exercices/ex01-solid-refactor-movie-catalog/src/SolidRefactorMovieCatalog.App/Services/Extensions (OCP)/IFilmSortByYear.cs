using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal interface IFilmSortByYear
    {
        IEnumerable<Film> ByYearDescending(IEnumerable<Film> films);
    }
}
