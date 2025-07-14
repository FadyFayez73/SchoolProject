using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Core.Dtos.Student;
using Core.Features.Students.Queries.Handlers;
using MediatR;
using Core.Features.Students.Queries.Modles;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("api/Students")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] Guid id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery() { Id = id });
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateStudentDto createStudentDto)
        {
            if (createStudentDto == null)
            {
                return BadRequest("Student data is null");
            }
            var (success, id) = await _mediator.Send(new CreateStudentQuery(createStudentDto));
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding student");
            }
            return CreatedAtAction(nameof(GetById), new { id }, new { id, createStudentDto });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentDto updateStudentDto)
        {
            if (updateStudentDto == null)
            {
                return BadRequest("Student data is null");
            }
            var success = await _mediator.Send(new UpdateStudentQuery(updateStudentDto));
            if (!success)
            {
                return StatusCode(StatusCodes.Status304NotModified, "subject Not Updated");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteStudentQuery(id));
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting student");
            }
            return NoContent();
        }
    }
}