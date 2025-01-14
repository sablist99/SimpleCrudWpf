using Domain.Model;

namespace CrudApplication.Dto
{
    public class ProjectDto : Project
    {
        public string SupervisorFio {  get; set; } = string.Empty;
    }
}
