using MovieFilter.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter.Filters
{
    public sealed class ActorFilter : DefaultFilter
    {
        private CheckBox checkBox;

        public ActorFilter(CheckBox checkBox)
        {
            this.checkBox = checkBox;
        }

        //to do: should be used
        public List<Actor> FilteredDataActors(int index)
        {
            return FilterDataActors()[index].Where(x => x.BirthDate == checkBox.Text || x.FirstName == checkBox.Text || x.LastName == checkBox.Text).ToList();
        }

        public List<string> FilterValuesActorsBirthDate(int index)
        {
            return FilterDataActors()[index].Select(x => x.BirthDate).Distinct().ToList();
        }

        public List<string> FilterValuesActorsLastName(int index)
        {
            return FilterDataActors()[index].Select(x => x.LastName).Distinct().ToList();
        }

        public List<string> FilterValuesActorsRole(int index)
        {
            return FilterDataActors()[index].Select(x => x.Role).Distinct().ToList();
        }
    }
}
