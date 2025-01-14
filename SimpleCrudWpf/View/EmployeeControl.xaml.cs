using SimpleCrudWpf.ViewModel;
using System.Windows.Controls;

namespace SimpleCrudWpf.View
{
    /// <summary>
    /// Логика взаимодействия для EmployeeControl.xaml
    /// </summary>
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl(EmployeeCrudTableViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
