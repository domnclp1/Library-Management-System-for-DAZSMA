using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Library_Management_System_for_DAZSMA
{
    public partial class LibrarianSignUp : Window
    {
        public LibrarianSignUp()
        {
            InitializeComponent();
            UpdatePasswordPlaceholder();
        }

        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (RevealToggle.IsChecked == true && PwdText.Text != PwdBox.Password)
            {
                PwdText.Text = PwdBox.Password;
                PwdText.CaretIndex = PwdText.Text.Length;
            }
            UpdatePasswordPlaceholder();
        }

        private void PwdText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RevealToggle.IsChecked == true && PwdBox.Password != PwdText.Text)
            {
                PwdBox.Password = PwdText.Text;
            }
            UpdatePasswordPlaceholder();
        }

        private void RevealToggle_Checked(object sender, RoutedEventArgs e)
        {
            PwdText.Visibility = Visibility.Visible;
            PwdBox.Visibility = Visibility.Collapsed;
            PwdText.Text = PwdBox.Password;
            RevealIcon.Text = "\uE8F4"; // Eye / reveal glyph
        }

        private void RevealToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            PwdBox.Visibility = Visibility.Visible;
            PwdText.Visibility = Visibility.Collapsed;
            PwdBox.Password = PwdText.Text;
            RevealIcon.Text = "\uE7B3"; // Original glyph
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string name = NameBox.Text.Trim();
            string email = EmailBox.Text.Trim();
            string password = RevealToggle.IsChecked == true ? PwdText.Text : PwdBox.Password;

            if (name.Length == 0 || email.Length == 0 || password.Length == 0)
            {
                MessageBox.Show("All fields are required.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.", "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!IsStrongPassword(password, out var pwdError))
            {
                MessageBox.Show(pwdError, "Validation", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Librarian account created successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            var login = new MainWindow();
            login.Show();
            Close();
        }

        private static bool IsStrongPassword(string password, out string error)
        {
            if (password.Length < 12)
            {
                error = "Password must be at least 12 characters long.";
                return false;
            }

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSymbol = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSymbol = true; // any non-letter/digit
            }

            var missing = new List<string>();
            if (!hasUpper) missing.Add("an uppercase letter");
            if (!hasLower) missing.Add("a lowercase letter");
            if (!hasDigit) missing.Add("a number");
            if (!hasSymbol) missing.Add("a symbol");

            if (missing.Count > 0)
            {
                error = $"Password must include {string.Join(", ", missing)}.";
                return false;
            }

            // Optional hint (not blocking): recommend 14+ chars
            if (password.Length < 14)
            {
                // non-blocking suggestion; no UI shown here to keep flow simple
            }

            error = string.Empty;
            return true;
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = new MainWindow();
            login.Show();
            Close();
        }

        private void SignUpAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Admin signup not implemented.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void UpdatePasswordPlaceholder()
        {
            string current = RevealToggle.IsChecked == true ? PwdText.Text : PwdBox.Password;
            PwdPlaceholder.Visibility = string.IsNullOrEmpty(current) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}