using Arcademy.Domain.Entities;
using Arcademy.Domain.Ports;
using MediatR;

namespace Arcademy.Application.Features.Courses.Queries;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        Course? course = await _courseRepository.GetCourseByIdAsync(request.Id);

        if (course is null)
        {
            return null;
        }

        return new CourseDto(course.Id, course.Title, course.Description, course.InstructorId, course.CreatedAt);
    }
}