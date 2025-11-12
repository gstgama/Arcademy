using Arcademy.Domain.Entities;

namespace Arcademy.Domain.Ports;

public interface ICourseRepository
{
    Task AddAsync(Course course);

    //TODO: The SaveChangesAsync is often part of a IUnitOfWork port, but for simplicity, we can start with it here.
    Task<int> SaveChangesAsync();
}