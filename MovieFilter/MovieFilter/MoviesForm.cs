using MovieFilter.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MovieFilter
{
    public partial class MoviesForm : Form
    {
        private BaseFilter baseFilter;

        public MoviesForm()
        {
            InitializeComponent();
            baseFilter = new BaseFilter();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                dataGridViewMovies.DataSource = baseFilter.GetAllMovies().Movie;

                //it will move

                var years = baseFilter.GetAllMovies().Movie.Select(x => x.Year).Distinct().ToList();
                var countries = baseFilter.GetAllMovies().Movie.Select(x => x.Country).Distinct().ToList();

                foreach (var item in years)
                {
                    comboBox1.Items.Add(item);
                }

                foreach (var item in countries)
                {
                    comboBox2.Items.Add(item);
                }
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

                additionalData.dataGridViewDirectors.DataSource = baseFilter.GetAllMovies().Movie[dataGridViewMovies.CurrentCell.RowIndex].Director;

                additionalData.dataGridViewActors.DataSource = baseFilter.GetAllMovies().Movie[dataGridViewMovies.CurrentCell.RowIndex].Actor;

                additionalData.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            YearFilter yearFilter = new YearFilter();

            dataGridViewMovies.DataSource = yearFilter.FilterData(comboBox1);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CountryFilter countryFilter = new CountryFilter();

            dataGridViewMovies.DataSource = countryFilter.FilterData(comboBox2);
        }
    }
}
