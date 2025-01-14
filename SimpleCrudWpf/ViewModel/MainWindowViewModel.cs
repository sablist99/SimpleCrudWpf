using WpfFrontCore.Infrastructure;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel(
            EmployeeCrudTableViewModel employeeControlViewModel,
            ProjectCrudTableViewModel projectControlViewModel,
            EmployeeOnProjectCrudTableViewModel employeeOnProjectControlViewModel)
        {
            EmployeeControlViewModel = employeeControlViewModel;
            ProjectControlViewModel = projectControlViewModel;
            EmployeeOnProjectControlViewModel = employeeOnProjectControlViewModel;
        }

        public ICrudTableViewModel EmployeeControlViewModel { get; set; }
        public ICrudTableViewModel ProjectControlViewModel { get; set; }
        public ICrudTableViewModel EmployeeOnProjectControlViewModel { get; set; }
    }
}
