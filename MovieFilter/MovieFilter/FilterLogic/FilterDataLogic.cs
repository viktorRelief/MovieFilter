using MovieFilter.Data;
using MovieFilter.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MovieFilter.FilterLogic
{
    public class FilterDataLogic<T>
    {
        private List<CheckBox> checkBoxFilters;
        private int cLeft;
        private DefaultFilter defaultFilter;

        public FilterDataLogic(DefaultFilter defaultFilter)
        {
            cLeft = 1;
            this.defaultFilter = defaultFilter;
        }

        public void FilterDataGrid(string methodName, GroupBox filtersGroupBox, object index = null)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(DefaultFilter).IsAssignableFrom(t) && t != typeof(DefaultFilter)).ToArray();

            List<List<T>> filterValues = new List<List<T>>();

            foreach (Type t in types)
            {
                var instance = Activator.CreateInstance(t, new CheckBox());

                var method = t.GetMethod(methodName);

                if (instance != null && method != null)
                {
                    switch (index)
                    {
                        case null:
                            filterValues.Add((List<T>)method.Invoke(instance, null));
                            break;
                        default:
                            filterValues.Add((List<T>)method.Invoke(instance, new[] { index }));
                            break;
                    }
                }
            }

            FullCheckBoxes(filterValues, filtersGroupBox);
        }

        private void FullCheckBoxes(List<List<T>> checkBoxData, GroupBox filtersGroupBox)
        {
            CheckBox checkBox;

            checkBoxFilters = new List<CheckBox>();

            foreach (var item in checkBoxData)
            {
                foreach (var i in item)
                {
                    checkBox = new CheckBox();
                    filtersGroupBox.Controls.Add(checkBox);
                    checkBox.Top = cLeft * 20;
                    checkBox.Width = 200;
                    checkBox.Left = 10;
                    checkBox.Text = i.ToString();
                    cLeft = cLeft + 1;

                    checkBoxFilters.Add(checkBox);
                }
            }

            cLeft = 1;
        }

        public void FilterData(DataGridView dataGridView, string filterDataMethod)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => typeof(DefaultFilter).IsAssignableFrom(t) && t != typeof(DefaultFilter)).ToArray();

            List<Movie> filteredValues = new List<Movie>();

            foreach (var checkBox in checkBoxFilters)
            {
                if (checkBox.Checked)
                {
                    foreach (Type t in types)
                    {
                        var instance = Activator.CreateInstance(t, checkBox);

                        var method = t.GetMethod(filterDataMethod);

                        if (instance != null && method != null && method.DeclaringType.IsSealed)
                        {
                            var data = (List<Movie>)method.Invoke(instance, null);

                            if (data.Count > 0)
                            {
                                filteredValues.AddRange(data);
                            }
                        }
                    }
                }
                else
                {
                    dataGridView.DataSource = defaultFilter.FilterDataMovies();
                }

                if (filteredValues.Count > 0)
                {
                    dataGridView.DataSource = filteredValues;
                }
            }
        }
    }
}
