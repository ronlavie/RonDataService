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
    /// Interaction logic for WindowRateMovie.xaml
    /// </summary>
    public partial class WindowRateMovie : Window
    {
        Movie movie;
        User user;
        public WindowRateMovie(Movie movie, User user)
        {
            InitializeComponent();
            this.movie = movie;
            this.DataContext = movie;   
            this.user = user;
            tbTitle.Text = user.UserName + " Rate the movie";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ServiceMovieAndShowClient myService = new ServiceMovieAndShowClient();
            myService.RateMovies(new RateMovie { User =user, Movie = movie,Stars=(int)RatingBar.Value });
            this.Close();
        }
    }
}
