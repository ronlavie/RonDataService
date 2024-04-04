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
    /// Interaction logic for UserControlTopShow.xaml
    /// </summary>
    public partial class UserControlTopShow : UserControl
    {
        public UserControlTopShow(Show show)
        {
            InitializeComponent();

            this.DataContext = show;
            ServiceMovieAndShowClient client = new ServiceMovieAndShowClient();
            RateShowList rates = client.GetShowRatingByShow(show);
            if (rates != null && rates.Count > 0)
                RatingBar.Value = rates.Average(s => s.Stars);
            else
                RatingBar.Value = 2.5;
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
