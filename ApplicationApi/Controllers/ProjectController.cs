using Application.BusinessLogic;
using Domain.Model;

namespace ApplicationApi.Controllers
{
    public class ProjectController(GenericService<Project> service) : GenericController<Project>(service)
    {
    }
}
