using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_RON.ServiceReferenceMovieAndShow;

namespace WPF_RON
{
    /// <summary>
    /// Interaction logic for WindowTopMovies.xaml
    /// </summary>
    public partial class WindowTopMovies : Window
    {

        private ServiceMovieAndShowClient myService;
        private User myUser;
        private MovieList movies;
        bool update;
       
        Dictionary<Movie, double> myMovies;
        int rows = 10;
        public WindowTopMovies(MovieList movies)
        {
            InitializeComponent();
            double avg;
            myMovies =new Dictionary<Movie, double>();
            foreach (Movie movie in movies)
            {
                ServiceMovieAndShowClient client = new ServiceMovieAndShowClient();
                RateMovieList rates = client.GetMovieRatingByMovie(movie);
                if (rates != null && rates.Count > 0)
                    avg = rates.Average(m => m.Stars);
                else
                    avg = 2.5;
                myMovies.Add(movie, avg);
            }
            List<KeyValuePair<Movie, double>> list = myMovies.ToList();
            list.Sort((first, next) => {
                return next.Value.CompareTo(first.Value);
            });
            listMovies.Children.Clear();
            foreach (KeyValuePair<Movie, double> entry in list)
            {
                rows--;
                if (rows == 0) break;
                TextBlock textBlock = new TextBlock();
                textBlock.FontSize = 15;
                textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                textBlock.VerticalAlignment = VerticalAlignment.Center;
                textBlock.Margin=new Thickness(0,3,0,0);
                textBlock.Text = entry.Key.MovieName+" - Rate "+entry.Value;
                listMovies.Children.Add(textBlock);
            }
           
        }
     
    }
}
