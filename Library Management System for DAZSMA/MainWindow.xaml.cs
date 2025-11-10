using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library_Management_System_for_DAZSMA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Password recovery feature coming soon!", "Forgot Password", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Update placeholder visibility
            if (PwdBox.Password.Length > 0)
            {
                PwdPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                PwdPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void PwdText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update placeholder visibility
            if (PwdText.Text.Length > 0)
            {
                PwdPlaceholder.Visibility = Visibility.Collapsed;
            }
            else
            {
                PwdPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private void RevealToggle_Checked(object sender, RoutedEventArgs e)
        {
            // Show password as text
            PwdText.Text = PwdBox.Password;
            PwdText.Visibility = Visibility.Visible;
            PwdBox.Visibility = Visibility.Collapsed;
            RevealIcon.Text = "\uE7B3"; // EyeHide icon
        }

        private void RevealToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            // Hide password
            PwdBox.Password = PwdText.Text;
            PwdBox.Visibility = Visibility.Visible;
            PwdText.Visibility = Visibility.Collapsed;
            RevealIcon.Text = "\uE8D4"; // Eye icon
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string password = PwdBox.Visibility == Visibility.Visible ? PwdBox.Password : PwdText.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: Implement actual login logic
            MessageBox.Show($"Login attempted for: {EmailBox.Text}", "Login", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}