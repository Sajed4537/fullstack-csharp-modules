using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App.Repository
{
    internal interface IFilmRepository
    {
        IEnumerable<Film> GetAll();
        Film? GetById(int id);
        void Add(Film film);
        void Remove(int id);
        void Update(Film film);
    }
}
