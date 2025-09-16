using SolidRefactorMovieCatalog.App.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App
{
    internal class FilmStatsService : IFilmStats
    {
        public IEnumerable<GenreStats> GroupByGenre(IEnumerable<Film> films)
        {
            if (films == null)
            {
                throw new ArgumentNullException(nameof(films));
            }

            if (!films.Any())
            {
                return Enumerable.Empty<GenreStats>();
            }
            
            var stats = films.GroupBy(f => string.IsNullOrWhiteSpace(f.Genre) ? "Inconnu" : f.Genre.Trim(),StringComparer.OrdinalIgnoreCase).Select(g => 
            new GenreStats
            {
                    Genre = g.Key,                           
                    Count = g.Count(),                       
                    AverageNote = g.Average(f => f.NoteSur10),
                    MinNote = g.Min(f => f.NoteSur10),       
                    MaxNote = g.Max(f => f.NoteSur10),       
                    Top2 = g.OrderByDescending(f => f.NoteSur10).Take(2).ToList()
            }).OrderBy(s => s.Genre).ToList();

            return stats;
        }
    }
}
