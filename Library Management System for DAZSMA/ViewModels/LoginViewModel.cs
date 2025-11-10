using System.Windows;
using System.Windows.Input;

namespace Library_Management_System_for_DAZSMA.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ShellViewModel _shell;

        public LoginViewModel(ShellViewModel shell)
        {
            _shell = shell;
            LoginCommand = new RelayCommand(OnLogin);
            CreateAccountCommand = new RelayCommand(OnCreateAccount);
            ForgotPasswordCommand = new RelayCommand(OnForgotPassword);
            SwitchRoleCommand = new RelayCommand(OnSwitchRole);
            IsPasswordRevealed = false;
        }

        public ICommand LoginCommand { get; }
        public ICommand CreateAccountCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        public ICommand SwitchRoleCommand { get; }

        public string CurrentEmail { get; set; } = string.Empty;
        public string CurrentPassword { get; set; } = string.Empty;

        private bool _isAdmin;
        public bool IsAdmin
        {
            get => _isAdmin;
            set { _isAdmin = value; RaisePropertyChanged(); RaisePropertyChanged(nameof(SwitchRoleText)); }
        }

        private bool _isPasswordRevealed;
        public bool IsPasswordRevealed
        {
            get => _isPasswordRevealed;
            set { _isPasswordRevealed = value; RaisePropertyChanged(); }
        }

        public string SwitchRoleText => IsAdmin ? "Log in as librarian" : "Log in as admin instead";

        private void OnLogin()
        {
            if (string.IsNullOrWhiteSpace(CurrentEmail))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(CurrentPassword))
            {
                MessageBox.Show("Please enter your password.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show($"Login attempted for: {CurrentEmail}", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnCreateAccount()
        {
            MessageBox.Show("Account creation coming soon.", "Account", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnForgotPassword()
        {
            MessageBox.Show("Password recovery feature coming soon!", "Forgot Password", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OnSwitchRole()
        {
            IsAdmin = !IsAdmin;
        }
    }
}
