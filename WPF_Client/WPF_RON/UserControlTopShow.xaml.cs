using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for UserControlTopShow.xaml
    /// </summary>
    public partial class UserControlTopShow : UserControl
    {
        public UserControlTopShow(Show show , double value , int rank)
        {
            InitializeComponent();
            DataContext = show;
            RatingBar.Value = value;
            if (rank == 1)
                tbRank.Text = "First Rank!";
            else if (rank == 2)
                tbRank.Text = "Second Rank!";
            else
                tbRank.Text = rank + "th!";
            try
            {
                img.Source = new BitmapImage(new Uri(show.PosterUrl));
            }
            catch (Exception ex)
            {
                img.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/Shows/smallLogo.png"));
            }
        }
    }
}
