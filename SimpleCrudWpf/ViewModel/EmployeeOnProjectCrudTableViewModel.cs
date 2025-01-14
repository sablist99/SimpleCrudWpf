using CrudApplication.Dto;
using Domain.Model;
using WpfFrontCore.Client;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class EmployeeOnProjectCrudTableViewModel : CrudTableViewModel<EmployeeOnProject>
    {
        public EmployeeOnProjectCrudTableViewModel(EmployeeOnProjectApiClient employeeClient) : base (employeeClient)
        {
            TableConfiguration =
            [
                new()
                {
                    FieldName = nameof(EmployeeOnProjectDto.ProjectTitle),
                    Label = "Проект",
                },
                new()
                {
                    FieldName = nameof(EmployeeOnProjectDto.EmployeeFio),
                    Label = "Сотрудник",
                },
            ];

            FetchDataDelegate = async () => await ((EmployeeOnProjectApiClient)Client).GetAllDtoAsync();
        }
    }
}
