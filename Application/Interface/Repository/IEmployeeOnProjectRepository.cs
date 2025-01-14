using CrudApplication.Dto;
using Domain.Model;

namespace CrudApplication.Interface.Repository
{
    public interface IEmployeeOnProjectRepository : IGenericRepository<EmployeeOnProject>
    {
        Task<List<EmployeeOnProjectDto>> GetAllDtoAsync();
    }
}
