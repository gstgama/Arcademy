using Arcademy.Application.Features.Courses.Queries;
using Arcademy.Domain.Entities;
using Arcademy.Domain.Ports;
using FluentAssertions;
using Moq;

namespace Arcademy.Application.Tests.Features.Courses.Queries;

public class GetCourseByIdQueryHandlerTests
{
    private readonly Mock<ICourseRepository> _mockCourseRepository;
    private readonly GetCourseByIdQueryHandler _handler;

    public GetCourseByIdQueryHandlerTests()
    {
        _mockCourseRepository = new Mock<ICourseRepository>();
        _handler = new GetCourseByIdQueryHandler(_mockCourseRepository.Object);
    }

    [Fact]
    public async Task Handle_Should_ReturnCourseDto_WhenCourseExists()
    {
        //ARRANGE
        Course course = new("Test", "Desc", Guid.NewGuid());

        _mockCourseRepository
            .Setup(repo => repo.GetCourseByIdAsync(course.Id))
            .ReturnsAsync(course);

        GetCourseByIdQuery query = new(course.Id);

        //ACT
        CourseDto? result = await _handler.Handle(query, CancellationToken.None);

        //ASSERT
        result.Should().NotBeNull();
        result.Should().BeOfType<CourseDto>();
        result.Id.Should().Be(course.Id);
    }

    [Fact]
    public async Task Handle_Should_ReturnNull_WhenCourseDoesNotExist()
    {
        //ARRANGE
        _mockCourseRepository
            .Setup(repo => repo.GetCourseByIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Course?)null);

        var query = new GetCourseByIdQuery(Guid.NewGuid());

        //ACT
        var result = await _handler.Handle(query, CancellationToken.None);

        //ASSERT
        result.Should().BeNull();
    }
}