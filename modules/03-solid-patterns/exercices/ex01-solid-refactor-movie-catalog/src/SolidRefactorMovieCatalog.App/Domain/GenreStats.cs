using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidRefactorMovieCatalog.App.Domain
{
    internal class GenreStats
    {
        public string Genre { get; init; }          
        public int Count { get; init; }             
        public double AverageNote { get; init; }   
        public int MinNote { get; init; }       
        public int MaxNote { get; init; }

        public IReadOnlyList<Film> Top2 { get; init; }
    }
}
