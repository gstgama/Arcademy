using MediatR;

namespace Arcademy.Application.Features.Courses.Commands;

public record CreateCourseCommand(string Title, string Description, Guid InstructorId): IRequest<Guid>;
