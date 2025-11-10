using System.Windows.Input;

namespace Library_Management_System_for_DAZSMA.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly ShellViewModel _shell;

        public ICommand? GoToLoginCommand { get; }

        public DashboardViewModel(ShellViewModel shell)
        {
            _shell = shell;
            GoToLoginCommand = new RelayCommand(() => { /* navigate later */ });
        }

        public string Title => "Dashboard";
    }
}
