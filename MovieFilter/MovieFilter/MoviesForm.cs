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
            catch(Exception ex)
            {
                throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AdditionalDataForm form2 = new AdditionalDataForm();

            int index = dataGridViewMovies.CurrentCell.RowIndex;

            form2.dataGridViewDirectors.DataSource = movies.Movie[dataGridViewMovies.CurrentCell.RowIndex].Director;

            form2.dataGridViewActors.DataSource = movies.Movie[dataGridViewMovies.CurrentCell.RowIndex].Actor;

            form2.Show();
        }
    }
}
