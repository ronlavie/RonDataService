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
    /// Interaction logic for WindowUserProfile.xaml
    /// </summary>
    public partial class WindowUserProfile : Window
    {
        private ServiceMovieAndShowClient myService;
        private User myUser;
        private MovieList movies;
        private ShowList shows;
        bool update;
        Show show;

        public WindowUserProfile(User user)
        {
            InitializeComponent();

            myService = new ServiceMovieAndShowClient();
            myUser = user;
            mAdmin.Visibility = user.PermissionLevel? Visibility.Visible: Visibility.Collapsed;
            //האם הסיסמה היא ברירת מחדל
            //מסך שינוי סיסמה
            if (myUser.Password == "CiniMeter1$")
            {
                ChangePassWindow changePassWindow = new ChangePassWindow();
                changePassWindow.ShowDialog();
            }
            this.DataContext = myUser;
            LoadShows();
            LoadMovies();
        }
        public WindowUserProfile()
        {
            InitializeComponent();
            myService = new ServiceMovieAndShowClient();
            myUser = new User { FirstName = "Ron", LastName = "X", PermissionLevel = false };
            this.DataContext = myUser;
            LoadShows(); LoadMovies();
        }


        public void LoadShows()
        {
            shows = myService.GetAllShowsFullData();
            pnlViewShows.Children.Clear();
            foreach (Show show in shows)
            {

                UserControlShow controlShow = new UserControlShow(show);
                controlShow.Margin = new Thickness(5);
                controlShow.Tag = show;
                controlShow.MouseDoubleClick += ControlShow_MouseDoubleClick;
                pnlViewShows.Children.Add(controlShow);
            }
        }
        public void LoadMovies()
        {
            movies = myService.GetAllMoviesFullData();
            pnlViewMovies.Children.Clear();
            foreach (Movie movie in movies)
            {
                UserControlMovie controlMovie = new UserControlMovie(movie);
                controlMovie.Margin = new Thickness(5);
                controlMovie.Tag = movie;
                controlMovie.MouseDoubleClick += ControlMovie_MouseDoubleClick;
                pnlViewMovies.Children.Add(controlMovie);
            }
        }

        private void ControlMovie_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Movie movie = ((UserControlMovie)sender).Tag as Movie;
            WindowRateMovie windowRate = new WindowRateMovie(movie, myUser);
            windowRate.ShowDialog();
            sender=new UserControlMovie(movie);
        }   
        private void ControlShow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Show show = ((UserControlShow)sender).Tag as Show;
            WindowRateShow windowRate = new WindowRateShow(show, myUser);
            windowRate.ShowDialog();
            sender=new UserControlShow(show);
        }

        private void lbShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            show = lbShows.SelectedValue as Show;
            update = true;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Top_Movies_Click(object sender, RoutedEventArgs e)
        {
            WindowTopMovies moviesWindow = new WindowTopMovies(movies);
            moviesWindow.ShowDialog();
        }

        private void Top_Shows_Click_(object sender, RoutedEventArgs e)
        {
            WindowTopShows showsWindow = new WindowTopShows(shows
          );
            showsWindow.ShowDialog();
        }
        private void Categories_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            WindowAdmin adminWindow = new WindowAdmin();
            adminWindow.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            adminWindow.ShowDialog();
        }
    }
}

