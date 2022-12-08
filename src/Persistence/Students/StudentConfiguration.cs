using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database;
using StudentManagementSystem.Entities;

namespace Persistence.Students;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Name).HasMaxLength(60);
        builder.Property(s => s.Email).HasMaxLength(60);
        
        builder.HasMany(s => s.Enrollments)
            .WithOne(e => e.Student);
        builder.HasMany(s => s.Disenrollments)
            .WithOne(e => e.Student);

        builder.HasData(SchoolDbInitializer.Students);
    }
}