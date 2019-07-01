using MovieFilter.Data;
using MovieFilter.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MovieFilter
{
    public partial class MoviesForm : Form
    {
        private DefaultFilter defaultFilter;
        private List<CheckBox> checkBoxFilters;
        private int cLeft = 1;

        public MoviesForm()
        {
            InitializeComponent();
            defaultFilter = new DefaultFilter();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                dataGridViewMovies.DataSource = defaultFilter.FilterData();

                FilterDataGrid();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dataGridViewMovies_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                AdditionalDataForm additionalData = new AdditionalDataForm();

                additionalData.dataGridViewDirectors.DataSource = defaultFilter.FilterData()[dataGridViewMovies.CurrentCell.RowIndex].Director;

                additionalData.dataGridViewActors.DataSource = defaultFilter.FilterData()[dataGridViewMovies.CurrentCell.RowIndex].Actor;

                additionalData.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void FilterDataGrid()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(DefaultFilter).IsAssignableFrom(t) && t != typeof(DefaultFilter)).ToArray();

            List<List<string>> filterValues = new List<List<string>>();

            foreach (Type t in types)
            {
                var instance = Activator.CreateInstance(t, new CheckBox());

                var method = t.GetMethod("FilterValues");

                if (instance != null && method != null)
                {
                    filterValues.Add((List<string>)method.Invoke(instance, null));
                }
            }

            FullCheckBoxes(filterValues);
        }

        public void FullCheckBoxes(List<List<String>> checkBoxData)
        {
            CheckBox checkBox;

            checkBoxFilters = new List<CheckBox>();

            foreach (var item in checkBoxData)
            {
                foreach (var i in item)
                {
                    checkBox = new CheckBox();
                    groupBox2.Controls.Add(checkBox);
                    checkBox.Top = cLeft * 20;
                    checkBox.Left = 10;
                    checkBox.Text = i;
                    cLeft = cLeft + 1;

                    checkBoxFilters.Add(checkBox);
                }
            }
        }

        private void filter_button_Click(object sender, MouseEventArgs e)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => typeof(DefaultFilter).IsAssignableFrom(t) && t != typeof(DefaultFilter)).ToArray();

            List<Movie[]> filterValues = new List<Movie[]>();

            foreach (var checkBox in checkBoxFilters)
            {
                if (checkBox.Checked)
                {
                    foreach (Type t in types)
                    {
                        var instance = Activator.CreateInstance(t, checkBox);

                        var method = t.GetMethod("FilterData");

                        if (instance != null && method != null)
                        {
                            var data = (List<Movie>)method.Invoke(instance, null);

                            if (data.Count > 0)
                            {
                                filterValues.Add(data.ToArray());
                            }
                        }
                    }
                }
                else
                {
                    dataGridViewMovies.DataSource = defaultFilter.FilterData();
                }

                if (filterValues.Count > 0)
                {
                    CreateFilterDataGrid(filterValues);
                }
            }
        }

        public void CreateFilterDataGrid(List<Movie[]> filterValues)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Title");
            table.Columns.Add("Year");
            table.Columns.Add("Country");
            table.Columns.Add("Genre");
            table.Columns.Add("Summary");

            foreach (var group in filterValues)
            {
                foreach (var item in group)
                {
                    table.Rows.Add(item.Title, item.Year, item.Country, item.Genre, item.Summary);
                }
            }

            dataGridViewMovies.DataSource = table;
        }
    }
}
