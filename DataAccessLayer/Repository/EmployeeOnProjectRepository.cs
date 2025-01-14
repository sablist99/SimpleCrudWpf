using CrudApplication.Dto;
using CrudApplication.Interface.Repository;
using DataAccessLayer.Context;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class EmployeeOnProjectRepository(ApplicationDbContext dbContext) : GenericRepository<EmployeeOnProject>(dbContext), IEmployeeOnProjectRepository
    {
        public async Task<List<EmployeeOnProjectDto>> GetAllDtoAsync()
        {
            return await Context.EmployeeOnProjects
                .Include(eop => eop.Employee)
                .Include(eop => eop.Project)
                .Select(eop => new EmployeeOnProjectDto
                {
                    Id = eop.Id,
                    EmployeeId = eop.EmployeeId,
                    ProjectId = eop.ProjectId,
                    EmployeeFio = eop.Employee != null
                        ? (eop.Employee.LastName + " " + eop.Employee.Name + " " + eop.Employee.Patronymic).Trim()
                        : string.Empty,
                    ProjectTitle = eop.Project != null
                        ? eop.Project.Title
                        : string.Empty
                })
                .ToListAsync();
        }

    }
}
