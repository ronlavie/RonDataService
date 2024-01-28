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
    /// Interaction logic for UserControlEditMovie.xaml
    /// </summary>
    public partial class UserControlEditMovie : UserControl
    {
        ServiceMovieAndShowClient service;
        MovieList movies;
        Movie movie;
        bool update;
        public UserControlEditMovie()
        {
            InitializeComponent();
            service=new ServiceMovieAndShowClient();
            cbCategory.ItemsSource=service.GetAllCategories();
            lbMovies.ItemsSource= movies=service.GetAllMovies();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbMovies.ItemsSource = movies.FindAll(m => m.MovieName.Contains(tbSearch.Text));
        }
        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movie=lbMovies.SelectedValue as Movie;
            spEdit.DataContext = movie;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(update)
            {
                service.UpdateMovies(movie);
            }
            else
            {
                service.InsertMovies(movie);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            update = false;
        }
    }
}
