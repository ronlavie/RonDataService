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
    /// Interaction logic for WindowCategory.xaml
    /// </summary>
    public partial class WindowCategory : Window
    {
        ShowList shows;
        MovieList movies;
        ServiceMovieAndShowClient service;
        public WindowCategory(CategoryList categories)
        {
            InitializeComponent();
            service = new ServiceMovieAndShowClient();
            shows = service.GetAllShowsFullData();
            movies = service.GetAllMoviesFullData();

            cbCategory.ItemsSource = service.GetAllCategories();
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedIndex = 0;
        }

        public void LoadShows(Category category)
        {
            pnlViewShows.Children.Clear();
            foreach (Show show in shows)
                if (show.ShowCategory.Id == category.Id)
                {
                    UserControlShow controlShow = new UserControlShow(show);
                    controlShow.Margin = new Thickness(5);
                    controlShow.Tag = show;
                    pnlViewShows.Children.Add(controlShow);
                }
        }
        public void LoadMovies(Category category)
        {
            pnlViewMovies.Children.Clear();
            foreach (Movie movie in movies)
                if(movie.MovieCategory.Id == category.Id)
            {
                UserControlMovie controlMovie = new UserControlMovie(movie);
                controlMovie.Margin = new Thickness(5);
                controlMovie.Tag = movie;
                pnlViewMovies.Children.Add(controlMovie);
            }
        }
        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category category = cbCategory.SelectedItem as Category;
            if (category != null) 
                LoadShows(category);
                LoadMovies(category);

        }
    }
}
