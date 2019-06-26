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
        private readonly DataSet dataSet;

        public Form1()
        {
            InitializeComponent();

            dataSet = new DataSet();                    
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //dataSet.ReadXml(@"Data\movies.xml");
            //dataGridView1.DataSource = dataSet.Tables[0];
            //dataGridView2.DataSource = dataSet.Tables[1];
            //dataGridView3.DataSource = dataSet.Tables[2];

            List<Movies> movies = new List<Movies>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Movies>), new XmlRootAttribute("movies"));

            using (FileStream fs = new FileStream(Environment.CurrentDirectory + @"\Data\movies.xml", FileMode.Open, FileAccess.Read))
            {
                movies = serializer.Deserialize(fs) as List<Movies>;
            }

            dataGridView1.DataSource = movies;
        }
    }
}
