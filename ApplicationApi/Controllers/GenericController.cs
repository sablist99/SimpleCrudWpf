using Application.BusinessLogic;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<T>(GenericService<T> service) : ControllerBase where T : Entity
    {
        protected readonly GenericService<T> Service = service ?? throw new ArgumentNullException(nameof(service));

        // Get all records
        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var entities = await Service.GetAllAsync();
            return Ok(entities);
        }

        // Get record by Id
        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var entity = await Service.GetByIdAsync(id);
            if (entity == null)
                return NotFound($"Entity with ID {id} not found.");
            return Ok(entity);
        }

        // Create new record
        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T entity)
        {
            if (entity == null)
                return BadRequest("Entity is null.");

            await Service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // Update existing record by Id
        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            if (entity == null || id != entity.Id)
                return BadRequest("Invalid entity data.");

            await Service.UpdateAsync(entity);
            return NoContent();
        }

        // Delete record
        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await Service.GetByIdAsync(id);
            if (entity == null)
                return NotFound($"Entity with ID {id} not found.");

            await Service.DeleteAsync(entity);
            return NoContent();
        }
    }
}