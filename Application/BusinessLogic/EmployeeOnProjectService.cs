using CrudApplication.Dto;
using CrudApplication.Interface.Repository;
using Domain.Model;

namespace CrudApplication.BusinessLogic
{
    public class EmployeeOnProjectService(IEmployeeOnProjectRepository repository) : GenericService<EmployeeOnProject>(repository)
    {
        public async Task<List<EmployeeOnProjectDto>> GetAllDtoAsync() => await ((IEmployeeOnProjectRepository)Repository).GetAllDtoAsync();
    }
}
