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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_RON.ServiceReferenceMovieAndShow;

namespace WPF_RON
{
    /// <summary>
    /// Interaction logic for UserControlMovie.xaml
    /// </summary>
    public partial class UserControlMovie : UserControl
    {
        public UserControlMovie()
        {
            InitializeComponent();
        }
        public UserControlMovie(Movie movie)
        {
            InitializeComponent();
            this.DataContext = movie;
            ServiceMovieAndShowClient client = new ServiceMovieAndShowClient();
            RateMovieList rates = client.GetMovieRatingByMovie(movie);
            if (rates != null && rates.Count > 0)
                RatingBar.Value = rates.Average(m => m.Stars);
            else
                RatingBar.Value = 2.5;
            try
            {
                img.Source = new BitmapImage(new Uri(movie.PosterUrl));
            }
            catch (Exception ex)
            {
                img.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/Shows/smallLogo.png"));
            }
        }
    }
}
