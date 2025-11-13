using Arcademy.Domain.Entities;
using Arcademy.Domain.Ports;

namespace Arcademy.Infrastructure.Persistence.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly ArcademyDbContext _context;

    public CourseRepository(ArcademyDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public async Task<Course?> GetCourseByIdAsync(Guid id)
    {
        return await _context.Courses.FindAsync(id);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}