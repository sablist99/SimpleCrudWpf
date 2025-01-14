using CrudApplication.Dto;
using CrudApplication.Interface.Repository;
using Domain.Model;

namespace CrudApplication.BusinessLogic
{
    public class ProjectService(IProjectRepository repository) : GenericService<Project>(repository)
    {
        public async Task<List<ProjectDto>> GetAllDtoAsync() => await ((IProjectRepository)Repository).GetAllDtoAsync();
    }
}
