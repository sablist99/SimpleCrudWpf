using Domain.Model;
using WpfFrontCore.Client;
using WpfFrontCore.Infrastructure;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICrudTableViewModel EmployeeCrud { get; set; } = null!;

        public MainWindowViewModel(ApiClient<Employee> employeeClient)
        {
            try
            {
                EmployeeCrud = new CrudTableViewModel<Employee>(employeeClient)
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
                    ],
                };
            } 
            catch (Exception ex) { }
        }
    }
}
