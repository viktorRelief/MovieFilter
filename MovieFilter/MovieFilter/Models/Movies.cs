﻿using System.Xml.Serialization;
using System.Collections.Generic;

namespace MovieFilter.Models
{
    [XmlRoot(ElementName = "movies")]
    public class Movies
    {
        [XmlElement(ElementName = "movie")]
        public List<Movie> Movie { get; set; }
    }

    [XmlRoot(ElementName = "movie")]
    public class Movie
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "year")]
        public string Year { get; set; }
        [XmlElement(ElementName = "country")]
        public string Country { get; set; }
        [XmlElement(ElementName = "genre")]
        public string Genre { get; set; }
        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }
        [XmlElement(ElementName = "director")]
        public List<Director> Director { get; set; }
        [XmlElement(ElementName = "actor")]
        public List<Actor> Actor { get; set; }
    }

    [XmlRoot(ElementName = "director")]
    public class Director
    {
        [XmlElement(ElementName = "last_name")]
        public string Last_name { get; set; }
        [XmlElement(ElementName = "first_name")]
        public string First_name { get; set; }
        [XmlElement(ElementName = "birth_date")]
        public string Birth_date { get; set; }
    }

    [XmlRoot(ElementName = "actor")]
    public class Actor
    {
        [XmlElement(ElementName = "first_name")]
        public string First_name { get; set; }
        [XmlElement(ElementName = "last_name")]
        public string Last_name { get; set; }
        [XmlElement(ElementName = "birth_date")]
        public string Birth_date { get; set; }
        [XmlElement(ElementName = "role")]
        public string Role { get; set; }
    }
}
