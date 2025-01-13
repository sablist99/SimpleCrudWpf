using Application.BusinessLogic;
using Domain.Model;

namespace ApplicationApi.Controllers
{
    public class EmployeeOnProjectController(GenericService<EmployeeOnProject> service) : GenericController<EmployeeOnProject>(service)
    {
    }
}
