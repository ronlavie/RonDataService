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
            service = new ServiceMovieAndShowClient();
            cbCategory.ItemsSource = service.GetAllCategories();
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "Id";
            lbMovies.ItemsSource = movies = service.GetAllMovies();
            lbMovies.SelectedIndex = 0;
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbMovies.ItemsSource = movies.FindAll(m => m.MovieName.Contains(tbSearch.Text));
        }
        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movie = lbMovies.SelectedValue as Movie;
            cbCategory.SelectedValue = movie.MovieCategory.Id;
            spEdit.DataContext = movie;
            update = true;
            tbInfo.Text=string.Empty;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbLength.Clear();
            tbAbout.Clear();
            spEdit.DataContext = movie = new Movie();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            movie.MovieCategory = cbCategory.SelectedItem as Category;
            if (update)
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
            tbName.Clear();
            tbLength.Clear();
            tbAbout.Clear();
            cbCategory.Text = string.Empty;
            spEdit.DataContext = movie = new Movie();
        }

        private void GetApi_Click(object sender, RoutedEventArgs e)
        {
            tbInfo.Text= service.GetMovieinfo(tbName.Text);
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            movie.About = tbInfo.Text;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show($"Delete {movie.MovieName}?","Delete",MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                service.DeleteMovies(movie);
            }
        }
    }
}
