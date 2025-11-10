using System.Windows;
using System.Windows.Controls;

namespace Library_Management_System_for_DAZSMA
{
    public partial class CreateNewPasswordWindow : Window
    {
        public CreateNewPasswordWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Enable confirm button only when both password fields have text and match
            bool passwordsNotEmpty = !string.IsNullOrWhiteSpace(NewPasswordBox.Password) && 
                                   !string.IsNullOrWhiteSpace(RetypePasswordBox.Password);
            
            bool passwordsMatch = NewPasswordBox.Password == RetypePasswordBox.Password;

            ConfirmPasswordButton.IsEnabled = passwordsNotEmpty && passwordsMatch;

            // Optional: Visual feedback for password mismatch
            if (passwordsNotEmpty && !passwordsMatch)
            {
                // You could add visual indicators here for password mismatch
            }
        }

        private void ConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            if (NewPasswordBox.Password != RetypePasswordBox.Password)
            {
                MessageBox.Show("Passwords do not match. Please try again.", "Password Mismatch",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NewPasswordBox.Password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Password Too Short",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // TODO: Implement actual password reset logic here
            MessageBox.Show("Password has been successfully reset!", "Password Reset",
                MessageBoxButton.OK, MessageBoxImage.Information);

            // Navigate back to login
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void LogInInstead_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Account creation coming soon.", "Create Account",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}