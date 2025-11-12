using Arcademy.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Arcademy.Infrastructure.Persistence;

public class ArcademyDbContext : IdentityDbContext
{
    public ArcademyDbContext(DbContextOptions<ArcademyDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ArcademyDbContext).Assembly);
    }
}