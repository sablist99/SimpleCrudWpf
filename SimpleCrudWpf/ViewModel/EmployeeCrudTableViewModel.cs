using Domain.Model;
using SimpleCrudWpf.View;
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

        protected override async Task Add()
        {
            var viewModel = new EmployeeEditViewModel();
            var confirmWindow = new EmployeeEditWindow { DataContext = viewModel };

            confirmWindow.ShowDialog();

            if (viewModel.DialogResult)
            {
                var newEmployee = new Employee
                {
                    Name = viewModel.Name,
                    LastName = viewModel.LastName,
                    Patronymic = viewModel.Patronymic,
                    Email = viewModel.Email,
                };

                await Client.CreateAsync(newEmployee);
                await Refresh();
            }
        }

        protected override async Task Edit()
        {
            var viewModel = new EmployeeEditViewModel(SelectedItem);
            var confirmWindow = new EmployeeEditWindow { DataContext = viewModel };

            confirmWindow.ShowDialog();

            if (viewModel.DialogResult)
            {
                SelectedItem.Name = viewModel.Name;
                SelectedItem.LastName = viewModel.LastName;
                SelectedItem.Patronymic = viewModel.Patronymic;
                SelectedItem.Email = viewModel.Email;

                await Client.UpdateAsync(SelectedItem.Id, SelectedItem);
                await Refresh();
            }
        }
    }
}
