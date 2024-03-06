using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using Model;
using ViewModel;

namespace ServiceModel
{
    public class ApiData
    {
        private static string apiKey = @"apikey=ada3cd49";
        private static string url = @"https://www.omdbapi.com/?t=[1234]&plot=full&r=xml&"+ apiKey;
        internal static void LoadMovieData(Movie movie)
        {
            string path = url.Replace("[1234]", movie.MovieName);
            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);

                            while (reader.MoveToNextAttribute())
                            {// Read the attributes.
                                if (reader.Name.Equals("poster"))
                                    movie.PosterUrl = reader.Value;
                                if (reader.Name.Equals("imdbRating"))
                                    movie.ImdbRating = double.Parse(reader.Value.ToString());
                                if (reader.Name.Equals("imdbVotes"))
                                    movie.ImdbVotes = int.Parse(reader.Value.ToString());
                                if (reader.Name.Equals("metascore"))
                                    movie.Metascore = int.Parse(reader.Value.ToString());
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        internal static string GetMovieData(string movieName)
        {
            string path = url.Replace("[1234]", movieName);
            string movieData = "";
            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);

                            while (reader.MoveToNextAttribute())
                            {// Read the attributes.
                                if (reader.Name.Equals("actors"))
                                    movieData += "Starring " + reader.Value + "\n";
                                if (reader.Name.Equals("plot"))
                                    movieData += reader.Value + "\n";
                            }
                            break;
                    }
                }
            }
            catch { }
            return movieData;
        }
        internal static void LoadShowsData(Show show)
        {
            string path = url.Replace("[1234]",show.ShowName);
            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);

                            while (reader.MoveToNextAttribute())
                            {// Read the attributes.
                                if (reader.Name.Equals("poster"))
                                    show.PosterUrl = reader.Value;
                                if (reader.Name.Equals("imdbRating"))
                                    show.ImdbRating = double.Parse(reader.Value.ToString());
                                if (reader.Name.Equals("imdbVotes"))
                                    show.ImdbVotes = int.Parse(reader.Value.ToString());
                                if (reader.Name.Equals("metascore"))
                                    show.Metascore = int.Parse(reader.Value.ToString());
                            }
                            break;
                    }
                }
            }
            catch { }
        }

        internal static string GetShowData(string showname)
        {
            string path = url.Replace("[1234]", showname);
            string showdata = "";
            try
            {
                XmlTextReader reader = new XmlTextReader(path);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            Console.Write("<" + reader.Name);

                            while (reader.MoveToNextAttribute())
                            {// Read the attributes.
                                if (reader.Name.Equals("actors"))
                                    showdata += "Starring " + reader.Value + "\n";
                                if (reader.Name.Equals("plot"))
                                    showdata += reader.Value + "\n";
                            }
                            break;
                    }
                }
            }
            catch { }
            return showdata;
        }
    }
}
