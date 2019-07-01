using MovieFilter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public class CountryFilter : DefaultFilter
    {
        private CheckBox checkBox;

        public CountryFilter(CheckBox checkBox)
        {
            this.checkBox = checkBox;
        }

        public override List<Movie> FilterData()
        {
            return base.FilterData().Where(x => x.Country == checkBox.Text).ToList();
        }

        public List<string> FilterValues()
        {
            return base.FilterData().Select(x => x.Country).Distinct().ToList();
        }
    }
}
