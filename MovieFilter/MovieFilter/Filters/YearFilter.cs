using MovieFilter.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public class YearFilter : DefaultFilter
    {
        private CheckBox checkBox;

        public YearFilter(CheckBox checkBox)
        {
            this.checkBox = checkBox;
        }

        public override List<Movie> FilterData()
        {
            return base.FilterData().Where(x => x.Year == checkBox.Text).ToList();
        }
        public List<string> FilterValues()
        {
            return base.FilterData().Select(x => x.Year).Distinct().ToList();
        }
    }
}
