using System.Windows;
using Library_Management_System_for_DAZSMA.ViewModels;

namespace Library_Management_System_for_DAZSMA
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Set the shell view model as DataContext so ContentControl {Binding CurrentViewModel} works
            DataContext = new ShellViewModel();
        }
    }
}
