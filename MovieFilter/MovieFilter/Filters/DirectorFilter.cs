using MovieFilter.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public sealed class DirectorFilter : DefaultFilter
    {
        private CheckBox checkBox;

        public DirectorFilter(CheckBox checkBox)
        {
            this.checkBox = checkBox;
        }

        public override List<List<Director>> FilterDataDirectors()
        {
            List<List<Director>> filteredDirectors = new List<List<Director>>();

            foreach (var item in base.FilterDataDirectors())
            {
                filteredDirectors.Add(item.Where(x => x.BirthDate == checkBox.Text || x.FirstName == checkBox.Text || x.LastName == checkBox.Text).ToList());
            }

            return filteredDirectors;
        }

        public List<List<string>> FilterValuesDirectors()
        {
            List<List<string>> filterValuesDirectors = new List<List<string>>();

            foreach (var item in base.FilterDataDirectors())
            {
                filterValuesDirectors.Add(item.Select(x => x.BirthDate).Distinct().ToList());
                filterValuesDirectors.Add(item.Select(x => x.FirstName).Distinct().ToList());
                filterValuesDirectors.Add(item.Select(x => x.LastName).Distinct().ToList());
            }

            return filterValuesDirectors;
        }
    }
}
