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
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "Id";
            lbShows.ItemsSource = shows = service.GetAllShows();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbShows.ItemsSource = shows.FindAll(m => m.ShowName.Contains(tbSearch.Text));
        }
        private void lbShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            show = lbShows.SelectedValue as Show;
            cbCategory.SelectedValue = show.ShowCategory.Id;
            spEdit.DataContext = show;
            update = true;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbDisc.Clear();
            spEdit.DataContext = show = new Show();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            show.ShowCategory = cbCategory.SelectedItem as Category;
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
            tbName.Clear();
            tbDisc.Clear();
            cbCategory.Text = string.Empty;
            spEdit.DataContext = show = new Show();
        }
        private void GetApi_Click(object sender, RoutedEventArgs e)
        {
            tbInfo.Text = service.GetShowinfo(tbName.Text);
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            show.ShowDescription = tbInfo.Text;
        }

    
    }
}
    

