using Arcademy.Application.Features.Courses.Commands;
using Arcademy.Domain.Entities;
using Arcademy.Domain.Ports;
using FluentAssertions;
using Moq;

namespace Arcademy.Application.Tests.Features.Courses.Commands;

public class CreateCourseCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_CallRepositoryAndReturnNewCourseId()
    {
        // ARRANGE (Setup)

        var mockCourseRepository = new Mock<ICourseRepository>();

        var command = new CreateCourseCommand(
            "Test Course",
            "Test Description",
            Guid.NewGuid()
        );

        var handler = new CreateCourseCommandHandler(mockCourseRepository.Object);

        // ACT (Execute)
        var result = await handler.Handle(command, CancellationToken.None);

        // ASSERT (Verify)

        mockCourseRepository.Verify(
            repo => repo.AddAsync(It.Is<Course>(
                c => c.Title == command.Title && c.Description == command.Description
            )),
            Times.Once
        );

        mockCourseRepository.Verify(
            repo => repo.SaveChangesAsync(),
            Times.Once
        );

        result.Should().NotBeEmpty();
    }
}