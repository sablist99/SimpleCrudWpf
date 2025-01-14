using CrudApplication.Dto;
using CrudApplication.Interface.Repository;
using DataAccessLayer.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class ProjectRepository(ApplicationDbContext dbContext) : GenericRepository<Project>(dbContext), IProjectRepository
    {
        public async Task<List<ProjectDto>> GetAllDtoAsync()
        {
            var a =  await Context.Projects
                .Include(p => p.Supervisor)
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Customer = p.Customer,
                    Performer = p.Performer,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Priority = p.Priority,
                    SupervisorId = p.SupervisorId,
                    SupervisorFio = p.Supervisor != null
                        ? $"{p.Supervisor.LastName} {p.Supervisor.Name} {p.Supervisor.Patronymic}".Trim()
                        : string.Empty
                })
                .ToListAsync();
            return a;
        }

    }
}
