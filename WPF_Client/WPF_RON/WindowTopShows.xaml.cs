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
    /// Interaction logic for WindowTopShows.xaml
    /// </summary>
    public partial class WindowTopShows : Window
    {
     
      
        private ServiceMovieAndShowClient myService;
        private User myUser;
        private ShowList shows;
        bool update;

        Dictionary<Show, double> myshows;
        int rows = 10;
        public WindowTopShows(ShowList shows)
        {
            InitializeComponent();
            double avg;
            //Get voting data
            myshows = new Dictionary<Show, double>();
            foreach (Show show in shows)
            {
                ServiceMovieAndShowClient client = new ServiceMovieAndShowClient();
                RateShowList rates = client.GetShowRatingByShow(show);
                if (rates != null && rates.Count > 0)
                    avg = rates.Average(m => m.Stars);
                else
                    avg = 2.5;
                myshows.Add(show, avg);
            }
            //Sort by average
            List<KeyValuePair<Show, double>> list = myshows.ToList();
            list.Sort((first, next) => {
                return next.Value.CompareTo(first.Value);
            });
            listShows.Children.Clear();

            foreach (KeyValuePair<Show, double> entry in list)
            {
                rows--;
                if (rows == 0) break;
                UserControlTopShow topShow = new UserControlTopShow(entry.Key, entry.Value, 10 - rows);
                listShows.Children.Add(topShow);
            }
        }
    }
}
