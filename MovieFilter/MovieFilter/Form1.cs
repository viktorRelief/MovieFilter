using MovieFilter.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MovieFilter
{
    public partial class Form1 : Form
    {
        private Movies movies;

        public Form1()
        {
            InitializeComponent();

            movies = new Movies();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {           
            XmlSerializer serializer = new XmlSerializer(typeof(Movies), new XmlRootAttribute("movies"));

            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\Data\\movies.xml", FileMode.Open))
            {
                movies = serializer.Deserialize(fs) as Movies;
            }

            dataGridViewMovies.DataSource = movies.Movie;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2 form2 = new Form2();

            int index = dataGridViewMovies.CurrentCell.RowIndex;

            form2.dataGridViewDirectors.DataSource = movies.Movie[dataGridViewMovies.CurrentCell.RowIndex].Director;

            form2.dataGridViewActors.DataSource = movies.Movie[dataGridViewMovies.CurrentCell.RowIndex].Actor;

            form2.Show();
        }
    }
}
