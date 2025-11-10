using System.Windows;
using System.Windows.Controls;

namespace Library_Management_System_for_DAZSMA.Helpers
{
    // Simple attached property to allow binding PasswordBox.Password to a ViewModel string property.
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper),
                new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject obj) => (string)obj.GetValue(BoundPasswordProperty);
        public static void SetBoundPassword(DependencyObject obj, string value) => obj.SetValue(BoundPasswordProperty, value);

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                // disconnect handler first
                passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

                var newPassword = (string?)e.NewValue ?? string.Empty;
                if (passwordBox.Password != newPassword)
                {
                    passwordBox.Password = newPassword;
                }

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetBoundPassword(passwordBox, passwordBox.Password);
            }
        }
    }
}
