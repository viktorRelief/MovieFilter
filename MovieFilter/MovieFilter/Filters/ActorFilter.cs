﻿using MovieFilter.Data;
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

        //public override List<List<Director>> FilterDataDirectors()
        //{
        //    List<List<Director>> filteredDirectors = new List<List<Director>>();

        //    foreach (var item in base.FilterDataDirectors())
        //    {
        //        filteredDirectors.Add(item.Where(x => x.BirthDate == checkBox.Text || x.FirstName == checkBox.Text || x.LastName == checkBox.Text).ToList());
        //    }

        //    return filteredDirectors;
        //}

        public List<string> FilterValuesActorsBirthDate(int index)
        {
            var list = FilterDataActors()[index].Select(x => x.BirthDate).Distinct().ToList();

            return list;
        }
    }
}