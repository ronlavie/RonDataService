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
    /// Interaction logic for UserControlEditShow.xaml
    /// </summary>
    public partial class UserControlEditShow : UserControl
    {
        ShowList shows;
        Show show;
        bool update;
        ServiceMovieAndShowClient service;
        public UserControlEditShow()
        {
            InitializeComponent();
            service = new ServiceMovieAndShowClient();
            cbCategory.ItemsSource = service.GetAllCategories();
            lbShows.ItemsSource = shows = service.GetAllShows();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbShows.ItemsSource = shows.FindAll(m => m.ShowName.Contains(tbSearch.Text));
        }
        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            show = lbShows.SelectedValue as Show;
            spEdit.DataContext = show;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbDisc.Clear();
        

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                service.UpdateShows(show);
            }
            else
            {
                service.InsertShows(show);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            update = false;

        }

        private void lbShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    

