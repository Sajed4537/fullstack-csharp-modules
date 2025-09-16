using SolidRefactorMovieCatalog.App.Domain;
using SolidRefactorMovieCatalog.App.Repository.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App.Repository
{
    internal class InMemoryFilmRepository: IFilmRepository
    {
        private readonly List<Film> Films;

        public InMemoryFilmRepository()
        {
            Films = new List<Film>();
        }


        public void Add(Film film)
        {
            bool filmAbsent = true;

            foreach (Film item in Films)
            {
                int id = item.Id;
                if(id == film.Id)
                {
                    filmAbsent = false;
                    throw new KeyAlreadyPresent();
                }
            }
            if (filmAbsent)
            {
                Films.Add(film);
            }
        }

        public IEnumerable<Film> GetAll()
        {
            return Films.ToList();
        }

        public Film GetById(int id)
        {

            Film film = Films.Where(i => i.Id == id).FirstOrDefault();

            if(film != null)
            {
                return film;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void Remove(int id)
        {
            bool filmPresent = false;

            for (int i = 0; i < Films.Count; i++)
            {
                int idTest = Films[i].Id;
                if (idTest == id)
                {
                    filmPresent = true;
                    Films.Remove(Films[i]);
                    break;
                }
            }
            if (!filmPresent)
            {
                throw new KeyNotFoundException();
            }

        }

        public void Update(Film film)
        {
            bool filmPresent = false;

            for (int i = 0; i < Films.Count; i++)
            {
                int idTest = Films[i].Id;

                if (idTest == film.Id)
                {
                    filmPresent = true;
                    Films[i].Annee = film.Annee;
                    Films[i].Genre = film.Genre;
                    Films[i].Titre = film.Titre;
                    Films[i].NoteSur10 = film.NoteSur10;
                    Films[i].Realisateur = film.Realisateur;
                    break;
                }
            }
            if (!filmPresent)
            {
                throw new KeyNotFoundException();
            }
        }
    }
}
