using Domain.Model;
using WpfFrontCore.Client;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class EmployeeCrudTableViewModel : CrudTableViewModel<Employee>
    {
        public EmployeeCrudTableViewModel(ApiClient<Employee> employeeClient) : base (employeeClient)
        {
            TableConfiguration =
            [
                new()
                {
                    FieldName = nameof(Employee.Name),
                    Label = "Имя",
                },
                new()
                {
                    FieldName = nameof(Employee.LastName),
                    Label = "Фамилия",
                },
                new()
                {
                    FieldName = nameof(Employee.Patronymic),
                    Label = "Отчество",
                },
                new()
                {
                    FieldName = nameof(Employee.Email),
                    Label = "Email",
                },
            ];
        }
    }
}
