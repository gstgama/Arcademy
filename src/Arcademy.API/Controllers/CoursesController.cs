using Arcademy.Application.Features.Courses.Commands;
using Arcademy.Application.Features.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Arcademy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly IMediator _mediator;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseBydId([FromRoute] Guid id)
    {
        GetCourseByIdQuery query = new(id);
        CourseDto? course = await _mediator.Send(query);

        return course is not null ? Ok(course) : NotFound();
    }
}