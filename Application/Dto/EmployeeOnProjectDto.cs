using Domain.Model;

namespace CrudApplication.Dto
{
    public class EmployeeOnProjectDto : EmployeeOnProject
    {
        public string EmployeeFio { get; set; } = string.Empty;
        public string ProjectTitle { get; set; } = string.Empty;
    }
}
