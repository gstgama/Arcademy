namespace Arcademy.Domain.Entities;

public class Course
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid InstructorId { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Course() { }

    public Course(string title, string description, Guid instructorId) 
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        InstructorId = instructorId;
        CreatedAt = DateTime.UtcNow;
    }
}