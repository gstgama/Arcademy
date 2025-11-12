using Arcademy.Domain.Entities;
using Arcademy.Domain.Ports;
using MediatR;

namespace Arcademy.Application.Features.Courses.Commands;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
{
    private readonly ICourseRepository _courseRepository;

    public CreateCourseCommandHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course(
            request.Title,
            request.Description,
            request.InstructorId
        );

        await _courseRepository.AddAsync(course);
        await _courseRepository.SaveChangesAsync();

        return course.Id;
    }
}