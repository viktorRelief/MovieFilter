using MovieFilter.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MovieFilter.FilterLogic
{
    public class FilterDataLogic<T, U>
    {      
        private int cLeft;
        private DefaultFilter defaultFilter;

        public FilterDataLogic(DefaultFilter defaultFilter)
        {
            cLeft = 1;
            this.defaultFilter = defaultFilter;
        }

        public void FilterDataGrid(string methodName, GroupBox filtersGroupBox, out List<CheckBox> checkBoxFilters, object index = null)
        {
            Type[] types = Assembly.Load("MoviesLibrary").GetTypes()
                .Where(t => typeof(DefaultFilter).IsAssignableFrom(t) && t != typeof(DefaultFilter)).ToArray();        

            List<T> filterValues = new List<T>();

            foreach (Type t in types)
            {
                var instance = Activator.CreateInstance(t, new CheckBox());

                var method = t.GetMethod(methodName);

                if (instance != null && method != null)
                {
                    switch (index)
                    {
                        case null:
                            filterValues.AddRange((List<T>)method.Invoke(instance, null));
                            break;
                        default:
                            filterValues.AddRange((List<T>)method.Invoke(instance, new[] { index }));
                            break;
                    }
                }
            }

            FullCheckBoxes(filterValues, filtersGroupBox, out checkBoxFilters);
        }

        private void FullCheckBoxes(List<T> filterValues, GroupBox filtersGroupBox, out List<CheckBox> checkBoxFilters)
        {
            CheckBox checkBox;
            checkBoxFilters = new List<CheckBox>();

            foreach (var item in filterValues)
            {
                checkBox = new CheckBox();
                filtersGroupBox.Controls.Add(checkBox);
                checkBox.Top = cLeft * 20;
                checkBox.Width = 200;
                checkBox.Left = 10;
                checkBox.Text = item.ToString();
                cLeft = cLeft + 1;

                checkBoxFilters.Add(checkBox);
            }

            cLeft = 1;
        }

        public void FilterData(DataGridView dataGridView, string filterDataMethod, List<CheckBox> checkBoxFilters, object index = null)
        {
            Type[] types = Assembly.Load("MoviesLibrary").GetTypes()
                    .Where(t => typeof(DefaultFilter).IsAssignableFrom(t) && t != typeof(DefaultFilter)).ToArray();

            HashSet<U> filteredValues = new HashSet<U>();

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
                            switch (index)
                            {                               
                                case null:
                                    filteredValues.UnionWith((List<U>)method.Invoke(instance, null));
                                    break;
                                default:
                                    filteredValues.UnionWith((List<U>)method.Invoke(instance, new[] { index }));
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    if (index == null)
                    {
                        dataGridView.DataSource = defaultFilter.FilterDataMovies();
                    }
                    else
                    {
                        dataGridView.DataSource = defaultFilter.FilterDataActors()[(int)index];
                    }
                }            
            }

            if (filteredValues.Count > 0)
            {
                dataGridView.DataSource = filteredValues.ToList();
            }
        }
    }
}
