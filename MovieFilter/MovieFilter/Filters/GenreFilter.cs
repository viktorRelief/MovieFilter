using MovieFilter.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public class GenreFilter : DefaultFilter
    {
        private CheckBox checkBox;

        public GenreFilter(CheckBox checkBox)
        {
            this.checkBox = checkBox;
        }

        public override List<Movie> FilterData()
        {
            return base.FilterData().Where(x => x.Genre == checkBox.Text).ToList();
        }
        public List<string> FilterValues()
        {
            return base.FilterData().Select(x => x.Genre).Distinct().ToList();
        }
    }
}
