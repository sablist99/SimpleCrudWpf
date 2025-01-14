using CrudApplication.BusinessLogic;
using Domain.Model;

namespace ApplicationApi.Controllers
{
    public class EmployeeController(GenericService<Employee> service) : GenericController<Employee>(service)
    {
    }
}
