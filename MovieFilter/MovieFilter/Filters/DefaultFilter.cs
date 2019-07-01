using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Linq;
using MovieFilter.Data;

namespace MovieFilter.Filters
{
    public class DefaultFilter : MoviesData
    {
        public virtual List<Movie> FilterData()
        {
            return GetAllMovies().Movie.ToList();
        }
    }
}
