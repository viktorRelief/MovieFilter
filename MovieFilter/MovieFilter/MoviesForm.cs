using MovieFilter.FilterLogic;
using MovieFilter.Filters;
using System;
using System.Windows.Forms;

namespace MovieFilter
{
    public partial class MoviesForm : Form
    {
        private DefaultFilter defaultFilter;
        private FilterDataLogic<string> filterDataLogic;

        public MoviesForm()
        {
            InitializeComponent();

            defaultFilter = new DefaultFilter();
            filterDataLogic = new FilterDataLogic<string>(defaultFilter);
        }

        private void MoviesForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                dataGridViewMovies.DataSource = defaultFilter.FilterDataMovies();

                filterDataLogic.FilterDataGrid("FilterValuesMovies", filtersGroupBox);
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

                additionalData.dataGridViewDirectors.DataSource = defaultFilter.FilterDataMovies()[dataGridViewMovies.CurrentCell.RowIndex].Director;

                additionalData.dataGridViewActors.DataSource = defaultFilter.FilterDataMovies()[dataGridViewMovies.CurrentCell.RowIndex].Actor;

                additionalData.index = dataGridViewMovies.CurrentCell.RowIndex;

                additionalData.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }    

        private void filter_button_Click(object sender, MouseEventArgs e)
        {
            filterDataLogic.FilterData(dataGridViewMovies, "FilterDataMovies");
        }       
    }
}
