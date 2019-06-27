using MovieFilter.Models;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MovieFilter
{
    public partial class MoviesForm : Form
    {
        private Movies movies;

        public MoviesForm()
        {
            InitializeComponent();

            movies = new Movies();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Movies), new XmlRootAttribute("movies"));

                using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Data\\movies.xml", FileMode.Open))
                {
                    movies = serializer.Deserialize(fs) as Movies;
                }

                dataGridViewMovies.DataSource = movies.Movie;
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

                additionalData.dataGridViewDirectors.DataSource = movies.Movie[dataGridViewMovies.CurrentCell.RowIndex].Director;

                additionalData.dataGridViewActors.DataSource = movies.Movie[dataGridViewMovies.CurrentCell.RowIndex].Actor;

                additionalData.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
