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
    /// Interaction logic for WindowSignin.xaml
    /// </summary>
    public partial class WindowSignin : Window
    {
        private bool UserNameOK, PassOK;
        private ServiceMovieAndShowClient myService;
        private User user;
        public WindowSignin()
        {
            InitializeComponent();
            UserNameOK = PassOK = false;
            myService = new ServiceMovieAndShowClient();
        }       
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Signin_Click(object sender, RoutedEventArgs e)
        {
            if (!UserNameOK || !PassOK)
            {
                MessageBox.Show("Errors found!\n FIX IT", "NO");
                return;
            }
            user = new User() { UserName = UserName.Text, Password = pbPassword.Password };
            user = myService.Login(user);
            if (user == null)
            {
                MessageBox.Show("no user detected");
                this.DataContext = user = new User();
                return;
            }
            if (user.PermissionLevel)
            {
                MessageBox.Show("nice Login");
                WindowAdmin mW = new WindowAdmin();
                mW.ShowDialog();
            }
            else
            {
                MessageBox.Show("Regular user login");
                WindowUserProfile wp = new WindowUserProfile(user);
                wp.ShowDialog();
            }
            UserName.Text = pbPassword.Password = string.Empty;
        }  
        private void tbxUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidationUserName valid = new ValidationUserName();

            ValidationResult result = valid.Validate(UserName.Text, null);
            if (!result.IsValid)
            {
                UserName.BorderBrush = Brushes.Red;
                UserName.Foreground = Brushes.Red;
                UserName.ToolTip = result.ErrorContent.ToString();
                UserNameOK = false;
            }
            else
            {
                UserName.BorderBrush = Brushes.Black;
                UserName.Foreground = Brushes.Black;
                UserName.ToolTip = null;
                UserNameOK = true;
            }
        }
        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidationPassword valid = new ValidationPassword();
            ValidationResult result = valid.Validate(pbPassword.Password, null);
            if (!result.IsValid)
            {
                pbPassword.BorderBrush = Brushes.Red;
                pbPassword.Foreground = Brushes.Red;
                pbPassword.ToolTip = result.ErrorContent.ToString();
                PassOK = false;
            }
            else
            {
                pbPassword.BorderBrush = Brushes.Black;
                pbPassword.Foreground = Brushes.Black;
                pbPassword.ToolTip = null;
                PassOK = true;
            }
        }
        private void GoTo_Signup(object sender, RoutedEventArgs e) 
        {
            WindowSignup windowSignup = new WindowSignup();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            windowSignup.ShowDialog();
            Close();
        }
    }
}
