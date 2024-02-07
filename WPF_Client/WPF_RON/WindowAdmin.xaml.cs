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
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window 
    {
        private User user;

        public WindowAdmin()
        {
            InitializeComponent();
        }

        public WindowAdmin(User user)
        {
            this.user = user;
        }

        private void GoTo_Category(object sender, RoutedEventArgs e)
        {
            UserControlEditCategory editCategory = new UserControlEditCategory();
            grMain.Children.Clear();
            grMain.Children.Add(editCategory);
        }

        private void GoTo_Show(object sender, RoutedEventArgs e)
        {
            UserControlEditShow editShow = new UserControlEditShow();
            grMain.Children.Clear();
            grMain.Children.Add(editShow);
        }

        private void GoTo_Movie(object sender, RoutedEventArgs e)
        {
            UserControlEditMovie editMovie=new UserControlEditMovie();
            grMain.Children.Clear();
            grMain.Children.Add(editMovie);
        }

        private void GoTo_Users(object sender, RoutedEventArgs e)
        {
            UserControlEditUser editUser = new UserControlEditUser();
            grMain.Children.Clear();
            grMain.Children.Add(editUser);
        }
    }
}
