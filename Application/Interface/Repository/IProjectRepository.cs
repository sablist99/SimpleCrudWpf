using CrudApplication.Dto;
using Domain.Model;

namespace CrudApplication.Interface.Repository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<List<ProjectDto>> GetAllDtoAsync();
    }
}
