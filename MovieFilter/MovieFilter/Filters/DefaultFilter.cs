using MovieFilter.Data;
using System.Collections.Generic;
using System.Linq;

namespace MovieFilter.Filters
{
    public class DefaultFilter : MoviesData
    {
        public virtual List<Movie> FilterDataMovies()
        {
            return GetAllMovies().Movie.ToList();
        }
    }
}
