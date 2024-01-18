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
        public WindowUserProfile(User user)
        {
            InitializeComponent();
            myService = new ServiceMovieAndShowClient();
            myUser = user;
            LoadShows();
            LoadMovies();           
        }
        public WindowUserProfile()
        {
            InitializeComponent();
            myService = new ServiceMovieAndShowClient();
            myUser = new User { Firstname = "Ron", Lastname = "X", PermissionLevel = false };
            LoadShows(); LoadMovies();
        }


        public void LoadShows()
        {
            ShowList shows = myService.GetAllShows();
            pnlViewShows.Children.Clear();
            foreach (var show in shows)
            {
                UserControlShow controlShow = new UserControlShow(show);
                controlShow.Margin = new Thickness(5);
                pnlViewShows.Children.Add(controlShow);
            }
        }
        public void LoadMovies()
        {
            MovieList movies = myService.GetAllMovies();
            pnlViewMovies.Children.Clear();
            foreach (var movie in movies)
            {
                UserControlMovie controlMovie = new UserControlMovie(movie);
                controlMovie.Margin = new Thickness(5);
                pnlViewMovies.Children.Add(controlMovie);
            }
        }
    }
}
