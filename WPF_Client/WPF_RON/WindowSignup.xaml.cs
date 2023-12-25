using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for WindowSignup.xaml
    /// </summary>
    public partial class WindowSignup : Window
    {
        private bool rePassOK, passOK;
        private ServiceMovieAndShowClient myService;
        public WindowSignup()
        {
            InitializeComponent();
        }


        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private bool CheckData()
        {
            if (tbUserName.Text.Equals(string.Empty)) return false;
            if (tbFirstName.Text.Equals(string.Empty)) return false;
            if (tbLastName.Text.Equals(string.Empty)) return false;
            if (pbPassword.Password.Equals(string.Empty)) return false;
            if (pbRePassword.Password.Equals(string.Empty)) return false;
            if (Validation.GetHasError(tbUserName)) return false;
            if (Validation.GetHasError(tbFirstName)) return false;
            if (Validation.GetHasError(tbLastName)) return false;
            if (!passOK) return false;
            if (!rePassOK) return false;
            return true;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void pbRePassword_RePasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password.Equals(pbRePassword.Password))
            {
                pbRePassword.BorderBrush = Brushes.Aqua;
                HintAssist.SetHelperText(pbRePassword, "Passwords match");
                rePassOK = true;
            }
            else
            {
                pbRePassword.BorderBrush = Brushes.Red;
                HintAssist.SetHelperText(pbRePassword, "Passwords DO NOT match");
                rePassOK= false;
            }

        }

        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidationPassword valid = new ValidationPassword();
            ValidationResult result = valid.Validate(pbPassword.Password, null);
            if (!result.IsValid)
            {
                pbPassword.BorderBrush = Brushes.Red;
                result.ErrorContent.ToString();
                HintAssist.SetHelperText(pbPassword, result.ErrorContent.ToString());
                passOK = false;
            }
            else
            {
                pbPassword.BorderBrush = Brushes.Black;
                pbPassword.Foreground = Brushes.Black;
                pbPassword.ToolTip = null;
                passOK = true;
            }
        }
    }
}
