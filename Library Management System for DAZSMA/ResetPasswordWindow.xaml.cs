using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Library_Management_System_for_DAZSMA
{
    public partial class ResetPasswordWindow : Window
    {
        private bool codeSent = false;

        public ResetPasswordWindow()
        {
            InitializeComponent();
        }

        private void SendCode_Click(object sender, RoutedEventArgs e)
        {
            var email = ResetEmailBox.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address first.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Send code (always 1234 for now)
            MessageBox.Show($"Verification code 1234 has been sent to {email}!", "Code Sent",
                MessageBoxButton.OK, MessageBoxImage.Information);

            // Enable code input
            CodeBox.IsEnabled = true;
            codeSent = true;

            // Change button to "Resend Code" and make it blue
            SendCodeButtonText.Text = "Resend Code";
            SendCodeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2731CF"));
        }

        private void CodeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Check if code is 1234
            if (CodeBox.Text == "1234")
            {
                CreatePasswordButton.IsEnabled = true;
            }
            else
            {
                CreatePasswordButton.IsEnabled = false;
            }
        }

        private void CreateNewPassword_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Navigate to set new password screen
            MessageBox.Show("Password reset functionality coming soon!", "Reset Password",
                MessageBoxButton.OK, MessageBoxImage.Information);
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