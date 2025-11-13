namespace Arcademy.Application.Features.Courses.Queries;

public record CourseDto(Guid Id, string Title, string Description, Guid InstructorId, DateTime CreatedAt);