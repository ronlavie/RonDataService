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
    /// Interaction logic for UserControlShow.xaml
    /// </summary>
    public partial class UserControlShow : UserControl
    {
        public UserControlShow()
        {
            InitializeComponent();
        }
        public UserControlShow(Show show)
        {
            InitializeComponent();
            this.DataContext = show;
            try
            {
                img.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/Shows/{show.Id}.png"));
            }
            catch (Exception ex)
            {
                img.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/Shows/smallLogo.png"));
            }
        }
    }
}
