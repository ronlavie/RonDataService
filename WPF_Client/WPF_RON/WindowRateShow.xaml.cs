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
    /// Interaction logic for WindowRateShow.xaml
    /// </summary>
    public partial class WindowRateShow : Window
    {
         User user;
         Show show;
        public WindowRateShow(Show show,User user)
        {
            InitializeComponent();
            this.show = show;
            this.DataContext = show;
            this.user = user;
            tbTitle.Text = user.UserName + " rate the movie";
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ServiceMovieAndShowClient myService = new ServiceMovieAndShowClient();
            myService.RateMovies(new RateMovie { User = user, Show = show, Stars = (int)RatingBar.Value });
            this.Close();
        }
    }
}
}
