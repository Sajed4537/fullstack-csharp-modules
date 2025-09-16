using SolidRefactorMovieCatalog.App.Domain;
using SolidRefactorMovieCatalog.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal class FilmSearchService : IFilmSearch
    {
        private readonly IFilmRepository _filmRepository;

        public FilmSearchService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public IEnumerable<Film> FindByGenre(string genre)
        {
            var films = _filmRepository.GetAll();

            var listeFiltre = films.Where(i => i.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();

            return listeFiltre;
        }

        public IEnumerable<Film> FindByTitle(string title)
        {
            var films = _filmRepository.GetAll();

            var filmTrouve = films.Where(i => i.Titre.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();

            return filmTrouve;
        }

        public Film? GetById(int id)
        {
            return _filmRepository.GetById(id);
        }

    }
}
