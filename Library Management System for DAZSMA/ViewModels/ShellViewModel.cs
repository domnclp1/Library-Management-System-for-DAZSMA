using System;

namespace Library_Management_System_for_DAZSMA.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private ViewModelBase? _currentViewModel;

        public ViewModelBase? CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ShellViewModel()
        {
            // Start with the Login screen
            CurrentViewModel = new LoginViewModel(this);
        }

        public void NavigateTo(ViewModelBase vm)
        {
            CurrentViewModel = vm;
        }
    }
}
