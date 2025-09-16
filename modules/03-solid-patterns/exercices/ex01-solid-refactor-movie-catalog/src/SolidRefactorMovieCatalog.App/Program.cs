using SolidRefactorMovieCatalog.App.Domain;
using SolidRefactorMovieCatalog.App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidRefactorMovieCatalog.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Film> listFilms = new List<Film>()
            {
                new Film(1, "Inception", "Science-Fiction", 9, 2010, "Christopher Nolan"),
                new Film(2, "The Dark Knight", "Action", 10, 2008, "Christopher Nolan"),
                new Film(3, "Interstellar", "Science-Fiction", 9, 2014, "Christopher Nolan"),
                new Film(4, "Parasite", "Thriller", 9, 2019, "Bong Joon-ho"),
                new Film(5, "Spirited Away", "Animation", 10, 2001, "Hayao Miyazaki"),
                new Film(6, "Avengers: Endgame", "Super-Hero", 8, 2019, "Anthony Russo"),
                new Film(7, "Titanic", "Romance", 9, 1997, "James Cameron"),
                new Film(8, "The Matrix", "Science-Fiction", 9, 1999, "Lana Wachowski"),
                new Film(9, "The Godfather", "Crime", 10, 1972, "Francis Ford Coppola"),
                new Film(10, "The Shawshank Redemption", "Drama", 10, 1994, "Frank Darabont"),
                new Film(11, "Inception", "Science-Fiction", 9, 2010, "Christopher Nolan"),
                new Film(12, "Gladiator", "Action", 9, 2000, "Ridley Scott"),
                new Film(13, "Joker", "Drama", 8, 2019, "Todd Phillips"),
                new Film(14, "La La Land", "Musical", 8, 2016, "Damien Chazelle"),
                new Film(15, "Fight Club", "Drama", 9, 1999, "David Fincher"),
                new Film(16, "The Lion King", "Animation", 10, 1994, "Roger Allers")
            };

            InMemoryFilmRepository repo = new InMemoryFilmRepository();

            IFilmService filmService = new FilmService(repo);

            IFilmSearch filmSearch = new FilmSearchService(repo);

            IFilmSort filmSort = new FilmSortService();

            IFilmStats filmStats = new FilmStatsService();

            var filmTest = new Film(1, "Inception 2", "Science-Fiction", 9, 2028, "Christopher Nolan");

            var filmAAjouter = new Film(17, "Film test", "Genre", 9, 2028, "Réalisateur");

            foreach(var item in listFilms)
            {
                filmService.Add(item);
            }

            Console.WriteLine("PREMIER PRINT");

            foreach (var item in filmService.GetAll())
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("SUPPRESSION D'UN FILM (ID : 15)");

            filmService.Remove(15);

            foreach (var item in filmService.GetAll())
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MAJ D'UN FILM (ID : 1)");

            filmService.Update(filmTest);

            foreach (var item in filmService.GetAll())
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("RETROUVER PAR TITRE (Titre : Joker)");

            foreach(var item in filmSearch.FindByTitle("Joker"))
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("RETROUVER PAR GENRE (Genre : Animation)");

            foreach (var item in filmSearch.FindByGenre("Animation"))
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("RETROUVER PAR ID (ID : 1)");

            Console.WriteLine(filmSearch.GetById(1).Titre);


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TRI NOTE DECROISSANT");

            var lists = filmService.GetAll();

            foreach (var item in filmSort.ByNoteDescending(lists))
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TRI NOTE CROISSANT");

            foreach (var item in filmSort.ByNoteAscending(lists))
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TRI TITRE");

            foreach (var item in filmSort.ByTitleAscending(lists))
            {
                item.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("GROUPE PAR GENRE");

            Console.WriteLine();

            foreach(var item in filmStats.GroupByGenre(lists))
            {
                Console.WriteLine($"Genre : {item.Genre}");
                Console.WriteLine($"Compte : {item.Count}");
                Console.WriteLine($"Note maximal : {item.MaxNote}");
                Console.WriteLine($"Note minimal : {item.MinNote}");
                Console.WriteLine($"Moyenne : {item.AverageNote}");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("TRI ANNEE");

            IFilmSortByYear filmSortByYear = new FilmSortByYearService();

            foreach (var item in filmSortByYear.ByYearDescending(lists))
            {
                item.Afficher();
            }

        }
    }
}