using Domain.Model;
using WpfFrontCore.Client;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class EmployeeOnProjectCrudTableViewModel : CrudTableViewModel<EmployeeOnProject>
    {
        public EmployeeOnProjectCrudTableViewModel(ApiClient<EmployeeOnProject> employeeClient) : base (employeeClient)
        {
            TableConfiguration =
            [
                new()
                {
                    FieldName = nameof(EmployeeOnProject.EmployeeId),
                    Label = "Сотрудник",
                },
            ];
        }
    }
}
