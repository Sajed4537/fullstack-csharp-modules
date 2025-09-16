using System;

namespace MovieCatalog.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LISTE DE BASE");

            List<Film> listFilms = new List<Film>()
            {
                new Film(1, "Inception", "Science-Fiction", 9, "2010", "Christopher Nolan"),
                new Film(2, "The Dark Knight", "Action", 10, "2008", "Christopher Nolan"),
                new Film(3, "Interstellar", "Science-Fiction", 9, "2014", "Christopher Nolan"),
                new Film(4, "Parasite", "Thriller", 9, "2019", "Bong Joon-ho"),
                new Film(5, "Spirited Away", "Animation", 10, "2001", "Hayao Miyazaki"),
                new Film(6, "Avengers: Endgame", "Super-Hero", 8, "2019", "Anthony Russo"),
                new Film(7, "Titanic", "Romance", 9, "1997", "James Cameron"),
                new Film(8, "The Matrix", "Science-Fiction", 9, "1999", "Lana Wachowski"),
                new Film(9, "The Godfather", "Crime", 10, "1972", "Francis Ford Coppola"),
                new Film(10, "The Shawshank Redemption", "Drama", 10, "1994", "Frank Darabont"),
                new Film(11, "Inception", "Science-Fiction", 9, "2010", "Christopher Nolan"),
                new Film(5, "Gladiator", "Action", 9, "2000", "Ridley Scott"),
                new Film(12, "Joker", "Drama", 8, "2019", "Todd Phillips"),
                new Film(13, "La La Land", "Musical", 8, "2016", "Damien Chazelle"),
                new Film(14, "Fight Club", "Drama", 9, "1999", "David Fincher"),
                new Film(15, "The Lion King", "Animation", 10, "1994", "Roger Allers")
            };

            foreach(Film film in listFilms)
            {
                film.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Dictionary<int, Film> dictionnaireFilms = new Dictionary<int, Film>();    

            foreach(Film film in listFilms)
            {
                if (!dictionnaireFilms.ContainsKey(film.Id))
                {
                    dictionnaireFilms.Add(film.Id, film);
                }
            }

            HashSet<Film> hashsetFilm = new HashSet<Film>();

            foreach (Film film in listFilms)
            {
                hashsetFilm.Add(film);
            }

            Console.WriteLine("Hashset");
            foreach (Film film in hashsetFilm)
            {
                film.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Ajout d’un doublon refusé : {hashsetFilm.Add(listFilms[1])}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("LISTE INITIALE");
            foreach(Film film in listFilms)
            {
                film.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Film filmTest = new Film(99, "Interstellar", "Sci - Fi", 9,"2014", "Nolan");

            Console.WriteLine("AJOUT");
            AjouterFilm(filmTest,listFilms,dictionnaireFilms);

            AjouterFilm(listFilms[0], listFilms, dictionnaireFilms);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("RECHERCHE ID");
            RechercheParId(3, dictionnaireFilms);
            RechercheParId(999, dictionnaireFilms);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("RECHERCHE TITRE");
            RechercheParTitre("man", listFilms);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("RECHERCHE GENRE");
            RechercheParGenre("Action", listFilms);
            RechercheParGenre("Western", listFilms);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MAJ NOTE");
            MAJNoteFilm(7, listFilms[1], listFilms, dictionnaireFilms);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("SUPPRESSION");
            foreach (Film film in listFilms)
            {
                film.Afficher();
            }
            Console.WriteLine();
            Console.WriteLine();

            SupprimerFilm(filmTest, listFilms,dictionnaireFilms);

            foreach(Film film in listFilms)
            {
                film.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine();

            Pagination(listFilms);

            Console.WriteLine();
            Console.WriteLine();
            
            StatParGenre(listFilms);

        }

        public static void ListerFilm(List<Film> listFilms)
        {
            foreach(Film film in listFilms)
            {
                film.Afficher();
            }
        }

        public static void AjouterFilm(Film filmAAjouter, List<Film> listFilms, Dictionary<int, Film> dictionnaireFilms)
        {
            if (dictionnaireFilms.ContainsKey(filmAAjouter.Id))
            {
                Console.WriteLine("Attention ! Le film suivant et déjà présent.");
                filmAAjouter.Afficher();
            }
            else
            {
                dictionnaireFilms.Add(filmAAjouter.Id, filmAAjouter);
                listFilms.Add(filmAAjouter);
            }
        }

        public static void SupprimerFilm(Film filmASupprimer, List<Film> listFilms, Dictionary<int, Film> dictionnaireFilms)
        {
            if (!dictionnaireFilms.ContainsKey(filmASupprimer.Id))
            {
                Console.WriteLine("Attention ! Le film suivant n'est pas présent pour la suppression.");
                filmASupprimer.Afficher();
            }
            else if (dictionnaireFilms.ContainsKey(filmASupprimer.Id))
            {
                dictionnaireFilms.Remove(filmASupprimer.Id);

                if(listFilms.Where(i => i.Id == filmASupprimer.Id).FirstOrDefault()  == null)
                {
                    Console.WriteLine("Id introuvable dans la liste.");
                }
                else
                {
                    listFilms.Remove(listFilms.Where(i => i.Id == filmASupprimer.Id).FirstOrDefault());
                }
            }
        }

        public static void MAJNoteFilm(int nouvelleNote, Film filmAModifier, List<Film> listFilms, Dictionary<int, Film> dictionnaireFilms)
        {
            if (!dictionnaireFilms.ContainsKey(filmAModifier.Id))
            {
                Console.WriteLine("Attention ! Le film suivant n'est pas présent pour la modification.");
                filmAModifier.Afficher();
            }
            else if (dictionnaireFilms.ContainsKey(filmAModifier.Id) && (nouvelleNote >= 0 && nouvelleNote <= 10))
            {
                dictionnaireFilms[filmAModifier.Id].NoteSur10 = nouvelleNote;

                var filmDansListe = listFilms.FirstOrDefault(f => f.Id == filmAModifier.Id);

                if (filmDansListe != null)
                {
                    filmDansListe.NoteSur10 = nouvelleNote;
                    Console.WriteLine($"la note du film {filmAModifier.Titre} est passé à {nouvelleNote}/10 avec succès !");
                }
            }
            else 
            {
                Console.WriteLine("La valeur de la nouvelle note doit étre entre 0 et 10");
            }
        }
        

        public static void RechercheParId(int id, Dictionary<int, Film> dictionnaireFilms)
        {
            if (dictionnaireFilms.ContainsKey(id))
            {
                Console.WriteLine("Le film suivant a été trouvé via son Id :");
                dictionnaireFilms[id].Afficher();
            }
            else
            {
                Console.WriteLine("Le film n'a pas été trouvé via son Id.");
            }
        }

        public static void RechercheParTitre(string nom, List<Film> listFilms)
        {

            var filmTrouve = listFilms.Where(i => i.Titre.ToLower().Contains(nom.ToLower())).ToList();

            if(filmTrouve.Count > 0)
            {
                Console.WriteLine($"Les films suivants ont été trouvé via le titre : {nom}");
                
                foreach(Film film in filmTrouve)
                {
                    film.Afficher();
                }
                
            }
            else if (filmTrouve.Count == 0)
            {
                Console.WriteLine("Le film n'a pas été trouvé via son titre.");
            }
        }

        public static void RechercheParGenre(string genre, List<Film> listFilms)
        {

            var listeFiltre = listFilms.Where(i => i.Genre.ToLower() == genre.ToLower()).ToList();

            if(listeFiltre.Count > 0)
            {
                Console.WriteLine($"Les films suivant ont été trouvé via le genre : {genre}.");

                foreach(Film film in listeFiltre)
                {
                    film.Afficher();
                }
            }
            else if(listeFiltre.Count == 0)
            {
                Console.WriteLine($"Aucun film n'a été trouvé via le genre : {genre}.");
            }
        }

        public static List<Film> TriParTitre(List<Film> listFilms)
        {
            Console.WriteLine("La liste a été triée par ordre alphabétique via les titres.");

            return listFilms.OrderBy(i=>i.Titre).ToList();
        }

        public static List<Film> TriParNote(bool trieCroissant, bool trieDecroissant,  List<Film> listFilms)
        {
            
            if (trieDecroissant && !trieCroissant)
            {
                Console.WriteLine("La liste a été triée par ordre décroissant via la note des films.");
                return listFilms.OrderByDescending(i => i.NoteSur10).ToList();
            }
            else if (!trieDecroissant && trieCroissant)
            {
                Console.WriteLine("La liste a été triée par ordre croissant via la note des films.");
                return listFilms.OrderBy(i => i.NoteSur10).ToList();
            }
            else
            {
                Console.WriteLine("Vous devez choisir un seul mode de tri");
                return listFilms;
            }
        }

        public static void StatParGenre(List<Film> listFilms)
        {
            foreach(var group in listFilms.GroupBy(i => i.Genre))
            {
                Console.WriteLine($"Le genre : {group.Key}");

                Console.WriteLine($"Le total des films : {group.Count()}");

                Console.WriteLine($"La moyenne des notes des films : {group.Average(i=> i.NoteSur10)}");

                Console.WriteLine($"La note maximale est de {group.Max(i=> i.NoteSur10)}");

                Console.WriteLine($"La note minimal est de {group.Min(i => i.NoteSur10)}");

                foreach (Film film in group.OrderByDescending(i=>i.NoteSur10).Take(2))
                {
                    film.Afficher();
                }

                Console.WriteLine();
            }
        }

        public static void Pagination(List<Film> listFilms)
        {

            Console.WriteLine("--- PAGINATION : Page 1 ---");
            listFilms.Take(5).ToList().ForEach(i => i.Afficher());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--- PAGINATION : Page 2 ---");
            listFilms.Skip(5).Take(5).ToList().ForEach(i => i.Afficher());
        }
    }
}