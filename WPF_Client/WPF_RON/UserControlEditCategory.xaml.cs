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
    /// Interaction logic for UserControlEditCategory.xaml
    /// </summary>
    public partial class UserControlEditCategory : UserControl
    {
        CategoryList category;
        Category Categ;
        bool update;
        ServiceMovieAndShowClient service;
        public UserControlEditCategory()
        {
            InitializeComponent();
            service = new ServiceMovieAndShowClient();
            lbCategorys.ItemsSource = category = service.GetAllCategories();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbCategorys.ItemsSource = category.FindAll(m => m.CategoryName.Contains(tbSearch.Text));
        }
        private void lbCategorys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Categ = lbCategorys.SelectedValue as Category;
            spEdit.DataContext = Categ;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            update = false;

        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                service.UpdateCategory(Categ);
            }
            else
            {
                service.InsertCategory(Categ);
            }

        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
        }
    }
}
