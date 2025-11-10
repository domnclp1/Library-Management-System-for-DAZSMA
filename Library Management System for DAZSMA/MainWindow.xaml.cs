using System.Windows;
using System.Windows.Controls;

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

        // Librarian "Forgot Password" handler
        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Password recovery feature coming soon!", "Forgot Password",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Librarian password reveal sync
        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PwdPlaceholder.Visibility = string.IsNullOrEmpty(PwdBox.Password)
                ? Visibility.Visible
                : Visibility.Collapsed;

            if (RevealToggle.IsChecked == true)
                PwdText.Text = PwdBox.Password;
        }

        private void PwdText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RevealToggle.IsChecked != true)
                return;

            PwdPlaceholder.Visibility = string.IsNullOrEmpty(PwdText.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void RevealToggle_Checked(object sender, RoutedEventArgs e)
        {
            PwdText.Text = PwdBox.Password;
            PwdText.Visibility = Visibility.Visible;
            PwdBox.Visibility = Visibility.Collapsed;
            RevealIcon.Text = "\uE8D4"; // eye with slash
            PwdText.Focus();
            PwdText.CaretIndex = PwdText.Text.Length;
        }

        private void RevealToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            PwdBox.Password = PwdText.Text;
            PwdBox.Visibility = Visibility.Visible;
            PwdText.Visibility = Visibility.Collapsed;
            RevealIcon.Text = "\uE7B3"; // eye
            PwdBox.Focus();
        }

        // Librarian login
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailBox.Text;
            var password = PwdBox.Visibility == Visibility.Visible ? PwdBox.Password : PwdText.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: Replace with real librarian auth
            MessageBox.Show($"Librarian login attempted for: {email}", "Login",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Admin password reveal sync
        private void AdminRevealToggle_Checked(object sender, RoutedEventArgs e)
        {
            AdminPwdText.Text = AdminPwdBox.Password;
            AdminPwdText.Visibility = Visibility.Visible;
            AdminPwdBox.Visibility = Visibility.Collapsed;
            AdminRevealIcon.Text = "\uE8D4";
            AdminPwdText.Focus();
            AdminPwdText.CaretIndex = AdminPwdText.Text.Length;
        }

        private void AdminRevealToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            AdminPwdBox.Password = AdminPwdText.Text;
            AdminPwdBox.Visibility = Visibility.Visible;
            AdminPwdText.Visibility = Visibility.Collapsed;
            AdminRevealIcon.Text = "\uE7B3";
            AdminPwdBox.Focus();
        }

        private void AdminPwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            AdminPwdPlaceholder.Visibility = string.IsNullOrEmpty(AdminPwdBox.Password)
                ? Visibility.Visible
                : Visibility.Collapsed;

            if (AdminRevealToggle.IsChecked == true)
                AdminPwdText.Text = AdminPwdBox.Password;
        }

        private void AdminPwdText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (AdminRevealToggle.IsChecked != true)
                return;

            AdminPwdPlaceholder.Visibility = string.IsNullOrEmpty(AdminPwdText.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        // Admin login
        private void AdminLoginButton_Click(object sender, RoutedEventArgs e)
        {
            var email = AdminEmailBox.Text;
            var password = AdminPwdBox.Visibility == Visibility.Visible ? AdminPwdBox.Password : AdminPwdText.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your admin email address.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your admin password.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: Replace with real admin auth
            MessageBox.Show($"Admin login attempted for: {email}", "Admin Login",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Switch role panels
        private void SwitchRole_Click(object sender, RoutedEventArgs e)
        {
            if (LibrarianPanel.Visibility == Visibility.Visible)
            {
                LibrarianPanel.Visibility = Visibility.Collapsed;
                AdminPanel.Visibility = Visibility.Visible;
            }
            else
            {
                AdminPanel.Visibility = Visibility.Collapsed;
                LibrarianPanel.Visibility = Visibility.Visible;
            }
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            // TODO: librarian account creation
            MessageBox.Show("Librarian account creation coming soon.", "Account",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CreateAdminAccount_Click(object sender, RoutedEventArgs e)
        {
            // TODO: admin account creation
            MessageBox.Show("Admin account creation coming soon.", "Account",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}