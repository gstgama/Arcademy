using Arcademy.Application.Features.Courses.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Arcademy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
    {
        Guid courseId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetCourseBydId), new { id = courseId }, command);
    }

    [HttpGet]
    public IActionResult GetCourseBydId(Guid id) 
    {
        return Ok($"Getting course with id: {id}");
    }
}