using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public class CountryFilter : BaseFilter
    {
        public List<Movie> FilterData(ComboBox comboBox)
        {
            return GetAllMovies().Movie.Where(x => x.Country == comboBox.SelectedItem.ToString()).ToList();
        }
    }
}
