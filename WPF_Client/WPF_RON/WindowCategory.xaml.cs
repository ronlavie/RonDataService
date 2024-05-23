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
        Show show;
        bool update;
        ServiceMovieAndShowClient service;
        public WindowCategory(CategoryList categories)
        {
            InitializeComponent();
            service = new ServiceMovieAndShowClient();
            cbCategory.ItemsSource = service.GetAllCategories();
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "Id";
            InitializeComponent();
            
            LoadShows();
        }
        private void lbShows_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            cbCategory.SelectedValue = show.ShowCategory.Id;
           
     
        }

        public void LoadShows()
        {
            shows = service.GetAllShowsFullData();
            pnlViewShows.Children.Clear();
            foreach (Show show in shows)
                if (show.ShowCategory == cbCategory.SelectedValue) 
                {
                    {

                        UserControlShow controlShow = new UserControlShow(show);
                        controlShow.Margin = new Thickness(5);
                        controlShow.Tag = show;
                        pnlViewShows.Children.Add(controlShow);
                    }
                }
     
        }
    }
}
