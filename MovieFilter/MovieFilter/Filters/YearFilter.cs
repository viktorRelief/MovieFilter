using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public sealed class YearFilter : BaseFilter
    {
        public List<Movie> FilterData(ComboBox comboBox)
        {
            return GetAllMovies().Movie.Where(x => x.Year == comboBox.SelectedItem.ToString()).ToList();
        }
    }
}
