using CrudApplication.Dto;
using Domain.Model;
using WpfFrontCore.Client;
using WpfFrontCore.ViewModel;

namespace SimpleCrudWpf.ViewModel
{
    public class ProjectCrudTableViewModel : CrudTableViewModel<Project>
    {
        public ProjectCrudTableViewModel(ProjectApiClient employeeClient) : base(employeeClient)
        {
            TableConfiguration =
            [
                new()
                {
                    FieldName = nameof(ProjectDto.Title),
                    Label = "Название проекта",
                },
                new()
                {
                    FieldName = nameof(ProjectDto.Customer),
                    Label = "Заказчик",
                },
                new()
                {
                    FieldName = nameof(ProjectDto.Performer),
                    Label = "Исполнитель",
                },
                new()
                {
                    FieldName = nameof(ProjectDto.StartDate),
                    Label = "Дата начала",
                },
                new()
                {
                    FieldName = nameof(ProjectDto.EndDate),
                    Label = "Дата окончания",
                },
                new()
                {
                    FieldName = nameof(ProjectDto.Priority),
                    Label = "Приоритет",
                },
                new()
                {
                    FieldName = nameof(ProjectDto.SupervisorFio),
                    Label = "Руководитель проекта",
                },
            ];

            FetchDataDelegate = async () => await ((ProjectApiClient)Client).GetAllDtoAsync();
        }
    }
}
