using Core.Dtos.Department;
using Core.Dtos.Departments;
using Core.Features.Departments.Queries.Models;
using Core.Features.Students.Queries.Modles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var result = await _mediator.Send(new GetAllDepartmentsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetDepartmentByIdAsync([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            if (createDepartmentDto == null)
            {
                return BadRequest("Student data is null");
            }
            var (success, id) = await _mediator.Send(new CreateDepartmentQuery(createDepartmentDto));
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding student");
            }
            return CreatedAtAction(nameof(GetDepartmentById), new { id }, new { id, createDepartmentDto });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepartmentDto updateDepartmentDto)
        {
            if (updateDepartmentDto == null)
            {
                return BadRequest("Department data is null");
            }
            var success = await _mediator.Send(new UpdateDepartmentQuery(updateDepartmentDto));
            if (!success)
            {
                return StatusCode(StatusCodes.Status304NotModified, "subject Not Updated");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteDepartmentQuery(id));
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting department");
            }
            return NoContent();

        }
    }
}