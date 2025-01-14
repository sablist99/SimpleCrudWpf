using CrudApplication.BusinessLogic;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Controllers
{
    public class EmployeeOnProjectController(EmployeeOnProjectService service) : GenericController<EmployeeOnProject>(service)
    {
        // Get all DTO records
        [HttpGet("Dto")]
        public virtual async Task<IActionResult> GetAllDto()
        {
            var entities = await ((EmployeeOnProjectService)Service).GetAllDtoAsync();
            return Ok(entities);
        }
    }
}
