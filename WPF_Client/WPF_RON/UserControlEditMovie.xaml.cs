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
    /// Interaction logic for UserControlEditMovie.xaml
    /// </summary>
    public partial class UserControlEditMovie : UserControl
    {
        ServiceMovieAndShowClient service;
        MovieList movies;
        Movie movie;
        bool update;
        public UserControlEditMovie()
        {
            InitializeComponent();
            service=new ServiceMovieAndShowClient();
            cbCategory.ItemsSource=service.GetAllCategories();
            cbCategory.DisplayMemberPath = "CategoryName";
            cbCategory.SelectedValuePath = "Id";
            lbMovies.ItemsSource= movies=service.GetAllMovies();
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbMovies.ItemsSource = movies.FindAll(m => m.MovieName.Contains(tbSearch.Text));
        }
        private void lbMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            movie=lbMovies.SelectedValue as Movie;
            cbCategory.SelectedValue = movie.MovieCategory.Id;
            spEdit.DataContext = movie;
            update=true;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Clear();
            tbLength.Clear();
            tbAbout.Clear();
            spEdit.DataContext = movie=new Movie();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            movie.MovieCategory = cbCategory.SelectedItem as Category;
            if (update)
            {                
                service.UpdateMovies(movie);
            }
            else
            {
                service.InsertMovies(movie);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            update = false;
            tbName.Clear();
            tbLength.Clear();
            tbAbout.Clear();
            cbCategory.Text=string.Empty;
            spEdit.DataContext = movie = new Movie();
        }
    }
//    using System;
//using System.Collections.Generic;
//using System.IO;

//class Program
//    {
//        static void Main()
//        {
//            // Example usage
//            string filePath = "path_to_your_file.tsv";
//            string primaryTitle = "Carmencita";

//            string tconst = GetTConstByPrimaryTitle(filePath, primaryTitle);

//            if (tconst != null)
//            {
//                Console.WriteLine($"tconst for {primaryTitle}: {tconst}");
//            }
//            else
//            {
//                Console.WriteLine($"No matching tconst found for {primaryTitle}");
//            }
//        }

//        static string GetTConstByPrimaryTitle(string filePath, string targetTitle)
//        {
//            try
//            {
//                // Read all lines from the TSV file
//                string[] lines = File.ReadAllLines(filePath);

//                // Iterate through each line (starting from the second line as the first line contains headers)
//                for (int i = 1; i < lines.Length; i++)
//                {
//                    // Split the line into columns
//                    string[] columns = lines[i].Split('\t');

//                    // Check if the primaryTitle matches the targetTitle
//                    if (columns.Length >= 4 && columns[2].Equals(targetTitle, StringComparison.OrdinalIgnoreCase))
//                    {
//                        // Return the corresponding tconst
//                        return columns[0];
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }

//            // Return null if no match is found
//            return null;
//        }
    //}
}
