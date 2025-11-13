using MediatR;

namespace Arcademy.Application.Features.Courses.Queries;

public record GetCourseByIdQuery(Guid Id) : IRequest<CourseDto?>;