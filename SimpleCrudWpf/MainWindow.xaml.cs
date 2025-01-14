using Microsoft.Extensions.DependencyInjection;
using SimpleCrudWpf.View;
using SimpleCrudWpf.ViewModel;
using System.Windows;

namespace SimpleCrudWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            var employeeControl = App.ServiceProvider.GetRequiredService<EmployeeControl>();
            EmployeeControlPlaceholder.Content = employeeControl;
        }
    }
}