using Domain.Model;
using WpfFrontCore.Client;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class ProjectCrudTableViewModel : CrudTableViewModel<Project>
    {
        public ProjectCrudTableViewModel(ApiClient<Project> employeeClient) : base(employeeClient)
        {
            TableConfiguration =
            [
                new()
                {
                    FieldName = nameof(Project.Title),
                    Label = "Название проекта",
                },
                new()
                {
                    FieldName = nameof(Project.Customer),
                    Label = "Заказчик",
                },
                new()
                {
                    FieldName = nameof(Project.Performer),
                    Label = "Исполнитель",
                },
                new()
                {
                    FieldName = nameof(Project.StartDate),
                    Label = "Дата начала",
                },
                new()
                {
                    FieldName = nameof(Project.EndDate),
                    Label = "Дата окончания",
                },
                new()
                {
                    FieldName = nameof(Project.Priority),
                    Label = "Приоритет",
                },
                new()
                {
                    FieldName = nameof(Project.SupervisorId),
                    Label = "Руководитель проекта",
                },
            ];
        }
    }
}
