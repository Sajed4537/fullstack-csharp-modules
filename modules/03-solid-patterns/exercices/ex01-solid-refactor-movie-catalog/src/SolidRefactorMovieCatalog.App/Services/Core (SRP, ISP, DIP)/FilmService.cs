using SolidRefactorMovieCatalog.App.Domain;
using SolidRefactorMovieCatalog.App.Repository;
using SolidRefactorMovieCatalog.App.Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal class FilmService : IFilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public void Add(Film film)
        {
            
            if(ValidationFilm(film))
            {
                _filmRepository.Add(film);
            }
            else
            {
                throw new FilmInitialisationProblem("Attention ! le film que vous tentez d'ajouter a des valeurs d'initialisation anormales, le probléme concerne l'un de c'est paramètres (Titre/Genre/NoteSur10/Annee/Realisateur).");
            }
        }

        public IEnumerable<Film> GetAll()
        {
            return _filmRepository.GetAll();
        }

        public void Remove(int id)
        {
            _filmRepository.Remove(id);

        }

        public void Update(Film film)
        {

            if (ValidationFilm(film))
            {
                _filmRepository.Update(film);
            }
            else
            {
                throw new FilmInitialisationProblem("Attention ! le film que vous tentez d'ajouter a des valeurs d'initialisation anormales, le probléme concerne l'un de c'est paramètres (Titre/Genre/NoteSur10/Annee/Realisateur).");
            }
        }

        private bool ValidationFilm(Film film)
        {
            var anneeActuellePlusCinq = DateTime.Now.Year + 5;

            if (film != null && !string.IsNullOrWhiteSpace(film.Titre) && !string.IsNullOrWhiteSpace(film.Genre) && !string.IsNullOrWhiteSpace(film.Realisateur) && film.Annee > 1900 && film.Annee <= anneeActuellePlusCinq && film.NoteSur10 >= 0 && film.NoteSur10 <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
