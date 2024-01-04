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
        }
        public WindowUserProfile()
        {
            InitializeComponent();
            myService = new ServiceMovieAndShowClient();
            myUser = new User { Firstname = "Ron", Lastname = "X", PermissionLevel = false };
            LoadShows();
        }


        public void LoadShows()
        {
            ShowList shows = myService.GetAllShows();
            pnlViewShows.Children.Clear();
            for (int i = 0;i<20;i++) 
            {
                UserControlShow controlShow = new UserControlShow();
                controlShow.Margin = new Thickness(5);
                pnlViewShows.Children.Add(controlShow);
            }
        }

        private void ScrollViewer_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
