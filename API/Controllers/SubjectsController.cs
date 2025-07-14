using Core.Dtos.Subject;
using Core.Features.Subjects.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            var result = await _mediator.Send(new GetAllSubjectsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(Guid id)
        {
            var result = await _mediator.Send(new GetSubjectByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetSubjectByIdAsync([FromQuery] Guid id)
        {
            var result = await _mediator.Send(new GetSubjectByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateSubjectDto createSubjectDto)
        {
            if (createSubjectDto == null)
            {
                return BadRequest("Subject data is null");
            }
            var (success, id) = await _mediator.Send(new CreateSubjectQuery(createSubjectDto));
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding subject");
            }
            return CreatedAtAction(nameof(GetSubjectById), new { id }, new { id, createSubjectDto });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubjectDto updateSubjectDto)
        {
            if (updateSubjectDto == null)
            {
                return BadRequest("Subject data is null");
            }
            var success = await _mediator.Send(new UpdateSubjectQuery(updateSubjectDto));
            if (!success)
            {
                return StatusCode(StatusCodes.Status304NotModified, "subject Not Updated");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _mediator.Send(new DeleteSubjectQuery(id));
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting subject");
            }
            return NoContent();
        }
    }
}
