using CrudApplication.BusinessLogic;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Controllers
{
    public class ProjectController(ProjectService service) : GenericController<Project>(service)
    {
        // Get all DTO records
        [HttpGet("Dto")]
        public virtual async Task<IActionResult> GetAllDto()
        {
            var entities = await ((ProjectService)Service).GetAllDtoAsync();
            return Ok(entities);
        }
    }
}
